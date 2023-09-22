using AguasApp.Data.Entities;
using System.Collections.Generic;

namespace AguasApp.Models
{
    public class MeterReadingViewModel
    {
        public MeterReading MeterReading { get; set; } 
        public Customer Customer { get; set; }
        public WaterMeter WaterMeter { get; set; }

        public List<Customer> Customers { get; set; }
        public List<WaterMeter> WaterMeters { get; set; }
    }
}
