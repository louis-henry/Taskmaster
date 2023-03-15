using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Taskmaster.ViewModels
{
    public class SecureViewModel : IValidatableObject
    {
        public bool Register { get; set; }

        // Fields used for Login section

        [EmailAddress, Display(Name = "Email")]
        public string LoginEmail { get; set; }

        [DataType(DataType.Password), Display(Name = "Password")]
        public string LoginPassword { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        // Fields for Register section

        [Display(Name = "User Name")]
        public string RegisterName { get; set; }

        [EmailAddress, Display(Name = "Email")]
        public string RegisterEmail { get; set; }

        [DataType(DataType.Password), Display(Name = "Password")]
        public string RegisterPassword { get; set; }

        [DataType(DataType.Password), Display(Name = "Confirm password")]
        public string RegisterPasswordConfirm { get; set; }

        [Display(Name = "I agree to the terms and conditions")]
        public bool TermsConditions { get; set; }

        // Custom validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Register)
            {
                if (RegisterName == null || RegisterEmail == null || RegisterPassword == null || RegisterPassword != RegisterPasswordConfirm || TermsConditions == false)
                {
                    if (RegisterName == null)
                    {
                        yield return new ValidationResult("User name is required.", new List<string>() { "RegisterName" });
                    }
                    if (RegisterEmail == null)
                    {
                        yield return new ValidationResult("Email is required.", new List<string>() { "RegisterEmail" });
                    }
                    if (RegisterPassword == null)
                    {
                        yield return new ValidationResult("Password is required.", new List<string>() { "RegisterPassword" });
                    }
                    if (RegisterPassword != null && RegisterPassword.Length < 6)
                    {
                        yield return new ValidationResult("Password needs to be at least 6 characters.", new List<string>() { "RegisterPassword" });
                    }
                    if (RegisterPassword != null &&
                        (!RegisterPassword.Any(ch => !Char.IsLetterOrDigit(ch)) ||
                        !RegisterPassword.Any(ch => Char.IsUpper(ch)) ||
                        !RegisterPassword.Any(ch => Char.IsLower(ch)) ||
                        !RegisterPassword.Any(ch => Char.IsDigit(ch))))
                    {
                        yield return new ValidationResult("Password does not meet complexity requirements.", new List<string>() { "RegisterPassword" });
                    }
                    if (RegisterPassword != RegisterPasswordConfirm)
                    {
                        yield return new ValidationResult("Passwords need to match.", new List<string>() { "RegisterPasswordConfirm" });
                    }
                    if (TermsConditions == false)
                    {
                        yield return new ValidationResult("You must agree to the terms and conditions.", new List<string>() { "TermsConditions" });
                    }
                }
            }
            else
            {
                if (LoginEmail == null || LoginPassword == null)
                {
                    if (LoginEmail == null)
                    {
                        yield return new ValidationResult("Email address is required.", new List<string>() { "LoginEmail" });
                    }
                    if (LoginPassword == null)
                    {
                        yield return new ValidationResult("Password is required.", new List<string>() { "LoginPassword" });
                    }
                }
            }
        }
    }
}
