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
        //[Display(Name = "Actual Reading Number*")]
        public int Volume { get; set; } 

        [Required]
        [Display(Name = "Customer Name*")]
        public string CustomerName { get; set; } 

        [Required]
        public int Nif { get; set; }


        [Display(Name = "Counter Name*")]
        public string CounterName { get; set; }


        [Display(Name = "Counter Number*")]
        public int CounterNumber { get; set; } 

        public string Description { get; set; } 

    }  
}
