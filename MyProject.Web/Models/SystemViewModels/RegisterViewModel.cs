using System.ComponentModel.DataAnnotations;

namespace Identity.Web.Models.SystemViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(300)]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(300)]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [MaxLength(300)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}