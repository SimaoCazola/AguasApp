using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class WaterMeter : IEntity //Contador de Agua
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageId { get; set; }

        [Required]
        [Display(Name = "Customer Address*")]
        public Customer CustomerLocation { get; set; }

        [Required]
        [Display(Name = "Current Reading*")]
        public double CurrentReading { get; set; }

        [Required]
        [Display(Name = "Last Reading*")]
        public DateTime LastReadingDate { get; set; }

        [Required]
        [Display(Name = "Is Working*")]
        public bool IsWorking { get; set; } 


    }
}
