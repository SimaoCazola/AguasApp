using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class Technician : IEntity //Class "Técnico" (Technician):
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; } 

        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        [Display(Name = "Phone Numer*")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";

    }
}
