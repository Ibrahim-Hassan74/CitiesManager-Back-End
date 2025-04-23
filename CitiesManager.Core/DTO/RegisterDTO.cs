using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CitiesManager.Core.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Person Name")]
        public string PersonName { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} can't be blank")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        [Remote(action: "IsEmailAreadyRegister", "Account", ErrorMessage = "Email already in use")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "{0} can't be blank")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "Password must be at least {2} characters long.", MinimumLength = 5)]
        public string Password { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
