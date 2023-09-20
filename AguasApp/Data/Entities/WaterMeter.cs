using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class WaterMeter : IEntity //Contador de Agua
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        [NotMapped]
        //[Required]
        public IFormFile ImageFile { get; set; }

        public string Model { get; set; }

        [Display(Name = "Serial Number")]
        public int ReferenceNumber { get; set; } 

        //[Required]
        //[Display(Name = "Current Reading*")]
        //public double CurrentReading { get; set; }

        //[Required]
        //[Display(Name = "Last Reading*")]
        //public DateTime LastReadingDate { get; set; }

        //[Required]
        //[Display(Name = "Is Working*")]
        //public bool IsWorking { get; set; } 


    }
}
