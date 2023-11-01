using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AguasApp.Models
{
    public class EmailViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public string Pdf { get; set; }


        public IFormFile PdfFile { get; set; }
    }
}
