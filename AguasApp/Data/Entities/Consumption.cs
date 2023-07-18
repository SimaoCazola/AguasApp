using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class Consumption
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Volume { get; set; }


        public decimal Value => Price * (decimal)Volume;

        public string Escalation { get; set; }

        [Required]
        public DateTime ConsumptionDate { get; set; }

        public string Descriptions { get; set; }
        
    }
}
 