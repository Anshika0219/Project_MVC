using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TextingGameMVC.Models
{
    public class CreateModel
    {
        [Required]
        public string? Name { get; set; }
       [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]

        public string EmailId { get; set; } = null!;
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$",
           ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string? Password { get; set; }
        [Required]
       [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public string? MobileNo { get; set; }
      [Required]
       [Compare("Password", ErrorMessage = "Confirm Password doesn't match.")]
        public string? ConfirmPassword { get; set; }
    }
}
