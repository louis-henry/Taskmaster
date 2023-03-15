using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Taskmaster.Data;
using Taskmaster.Models;
using Taskmaster.ViewModels;

namespace Taskmaster.Controllers
{
    public class SecureController : Controller
    {
        private readonly TaskmasterContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<SecureViewModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;

        public SecureController(TaskmasterContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<SecureViewModel> logger, IConfiguration configuration, IEmailSender emailSender)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        // GET: Login
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        // POST: Login
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(SecureViewModel viewModel, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                if(viewModel.Register == false)
                {
                    var result = await _signInManager.PasswordSignInAsync(viewModel.LoginEmail, viewModel.LoginPassword, viewModel.RememberMe, lockoutOnFailure: false);
                    if(result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        
                        return View(viewModel);
                    }
                }
                else
                {
                    var user = new ApplicationUser();
                    user.UserName = user.Email = viewModel.RegisterEmail;
                    user.User = new User() { Name = viewModel.RegisterName, Email = viewModel.RegisterEmail, PublicProfile = false };
                    IdentityResult result = _userManager.CreateAsync(user, viewModel.RegisterPassword).Result;
                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "User").Wait();
                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                        // Create email confirmation - currently auto-confirming email.
                        //var callbackUrl = Url.Action("ConfirmEmail", "Secure", values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl });
                        //await _emailSender.SendEmailAsync(viewModel.RegisterEmail, "Confirm your email", $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                        //return RedirectToPage("~/Secure/RegisterConfirmation", new { email = viewModel.RegisterEmail, returnUrl = returnUrl });

                        // Auto-confirm account without sending email.
                        await _userManager.ConfirmEmailAsync(user, code);
                        await _signInManager.SignInAsync(user, false);
                        return LocalRedirect(returnUrl);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(viewModel);
        }

        // GET: ConfirmEmail
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("~/");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            var message = new MessageViewModel() { Message = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email." };

            return View(message);
        }

        // GET: RegisterConfirmation
        public async Task<IActionResult> RegisterConfirmation(string email, string returnUrl = null)
        {
            var message = new MessageViewModel();

            if (email == null)
            {
                return RedirectToPage("~/");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                message.Message = $"Unable to load user with email '{email}'.";
            }
            else 
            {
                message.Message = "Please check your email to confirm your account.";

            }

            return View(message);
        }

        // GET: Logout
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return LocalRedirect("~/");
            }
        }

        // GET: ChangePassword
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // POST: ChangePassword
        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(PasswordChangeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (User == null)
                {
                    return RedirectToAction(nameof(Login));
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
                return RedirectToAction(nameof(ChangePasswordConfirmation));
            }
            return View(model);
        }

        // GET: ChangePasswordConfirmation
        [Authorize]
        public IActionResult ChangePasswordConfirmation()
        {
            return View();
        }

        // GET: ForgotPassword
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: ForgotPassword
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                User userDb = _context.User
                    .Where(u => u.Email == model.Email)
                    .FirstOrDefault();

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var callbackOld = Url.Page("/Account/ResetPassword", pageHandler: null, values: new { area = "Identity", code }, protocol: Request.Scheme);

                var callbackUrl = Url.Action("ResetPassword", "Secure", values: new { id = userDb.UserID, code }, protocol: Request.Scheme);
                //await _emailSender.SendEmailAsync(model.Email, "Reset Password", $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                // Use SendMail to send reset email.
                var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
                var client = new SendGridClient(apiKey);
                var msg = MailHelper.CreateSingleEmail(new EmailAddress(_configuration.GetSection("SENDGRID_EMAIL").Value, "Taskmaster"), new EmailAddress(userDb.Email, userDb.Name), "Reset Password", "", $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                var response = await client.SendEmailAsync(msg);

                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            return View(model);
        }

        // GET: ForgotPasswordConfirmation
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // GET: ResetPassword
        public IActionResult ResetPassword(int? id, string code = null)
        {
            var model = new ResetPasswordViewModel();
            if (code == null || id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                User userDb = _context.User
                    .Where(u => u.UserID == id)
                    .FirstOrDefault();
                if(userDb == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                model.Email = userDb.Email;
                model.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            }

            return View(model);
        }

        // POST: ResetPassword
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        // GET: ResetPasswordConfirmation
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        // GET: AccessDenied
        public IActionResult AccessDenied()
        {
            return View(new MessageViewModel() { Message = "You do not have permission to view this content."});
        }
    }
}
