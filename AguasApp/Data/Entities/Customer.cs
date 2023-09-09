using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace AguasApp.Data.Entities
{
    public class Customer: IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Nif*")]
        public string Nif { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can contain {1}Characters length.")]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can contain {1}Characters length.")]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "Phone Number*")]
        public int PhoneNumber { get; set; }


        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name= "Postal Code*")]
        public string PostalCode { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
