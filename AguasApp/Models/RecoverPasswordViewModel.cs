using System.ComponentModel.DataAnnotations;

namespace AguasApp.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
