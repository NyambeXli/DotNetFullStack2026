//User Model
using System.ComponentModel.DataAnnotations;

namespace CodVeda_FullStack_Intern.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full names are required")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(7, ErrorMessage = "Password must be at least 7 characters long")]
        //[RegularExpression(@"^(?=.*[a-zA-Z])(?=.*[0-9\W]).+$", 
        //    ErrorMessage = "Password must contain at least one alphabet and at least one number or special character")]
        public string Password { get; set; } = string.Empty; 
    }
}
