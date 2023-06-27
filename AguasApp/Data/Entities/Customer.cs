using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace AguasApp.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Nif { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can contain {1}Characters length.")]
        public string Name { get; set; }
        public string Surname { get; set; }

        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        [Display(Name= "Postal Code")]
        public string PostalCode { get; set; }
        public string Email { get; set; }
    }
}
