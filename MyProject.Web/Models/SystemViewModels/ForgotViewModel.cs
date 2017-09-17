using System.ComponentModel.DataAnnotations;

namespace Identity.Web.Models.SystemViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}