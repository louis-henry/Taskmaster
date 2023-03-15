using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using Taskmaster.Data;
using Taskmaster.Models;
using Taskmaster.ViewModels;

namespace Taskmaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskmasterContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(TaskmasterContext context, IConfiguration configuration, ILogger<HomeController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // GET: Index
        public IActionResult Index()
        {
            var tasks = _context.Task;
            ViewBag.TasksNumber = tasks.Count();
            ViewBag.TasksComplete = tasks.Where(t => t.Completed).Count();

            return View();
        }

        // GET: About
        public IActionResult About()
        {
            return View();
        }

        // GET: ContactUS
        public IActionResult ContactUS()
        {
            var model = new ContactUsViewModel()
            {
                Sent = false
            };

            return View(model);
        }

        // POST: ContactUS
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUS(ContactUsViewModel model)
        {
            if(ModelState.IsValid)
            {
                var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
                var client = new SendGridClient(apiKey);
                var msg = MailHelper.CreateSingleEmail(new EmailAddress(_configuration.GetSection("SENDGRID_EMAIL").Value, "Taskmaster"), new EmailAddress(_configuration.GetSection("SENDGRID_EMAIL").Value, "Taskmaster"), "Taskmaster Contact Us Feedback", "", $"<table><tr><td>Name: </td><td>{model.FirstName} {model.Surname}</td></tr><tr><td>Email: </td><td>{model.Email}</td></tr><tr><td>Subject: </td><td>{model.Subject}</td></tr><tr><td>Message: </td><td>{model.Message}</td></tr></table>");
                var response = await client.SendEmailAsync(msg);

                model.Sent = true;
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
