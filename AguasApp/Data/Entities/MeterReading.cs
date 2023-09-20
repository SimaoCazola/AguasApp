using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class MeterReading : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Today Date*")]
        public DateTime TodayDate { get; set; }

        [Required]
        [Display(Name = "Actual Reading Number*")]
        public double RegisteredConsumption { get; set; }

        [Required]
        [Display(Name = "Customer Name*")]
        public Customer CustomerName { get; set; } 

        [Required]
        [Display(Name = "Customer Name*")]
        public Customer Nif { get; set; } 

    }  
}
