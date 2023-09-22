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

        
    }
}
