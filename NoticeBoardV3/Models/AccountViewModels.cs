using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoticeBoardV3.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "We couldn't recognise that email. Please enter a valid email address")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "We couldn't recognise that email. Please enter a valid email address")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "We couldn't recognise that email. Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "We couldn't recognise that email. Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //TODO: Create country table in database, create country Model, create api call to retrieve country, create ajax to call api and populate html select in registration form.

        //TODO: Create town/city table in database, create town/city Model, create api call to retrieve town/city, create ajax to call api and populate html select in registration form with all towns/cities of the selected country.

        //from https://forums.asp.net/t/2122845.aspx?How+to+Bind+country+list+Through+Web+API+in+MVC+

        [Required(ErrorMessage = "Please enter a location")]
        [Display(Name = "Location")]
        public Location Location { get; set; }

        [Required(ErrorMessage = "Please enter your gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "We couldn't recognise that email. Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "We couldn't recognise that email. Please enter a valid email address")]
        public string Email { get; set; }
    }
}
