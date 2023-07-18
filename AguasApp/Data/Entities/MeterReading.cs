using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class MeterReading 
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Reading Date*")]
        public DateTime ReadingDate { get; set; }

        [Required]
        [Display(Name = "Consumption*")]
        public Consumption RegisteredConsumption { get; set; }

        [Required]
        [Display(Name = "Customer*")]
        public Customer AssociatedCustomer { get; set; }

    }  
}
