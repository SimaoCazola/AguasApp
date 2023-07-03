using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class Meter
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        [Display(Name = "Installation Date")]
        public DateTime InstallationDate { get; set; }
    }  
}
