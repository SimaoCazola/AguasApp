using AguasApp.Data.Entities;
using System.Collections.Generic;

namespace AguasApp.Models
{
    public class CustomerServiceViewModel
    {
        public CustomerService CustomerService { get; set; }
        public Customer Customer { get; set; }
        public Technician Technician { get; set; }
        public WaterMeter WaterMeter { get; set; }

        public List<Customer> Customers { get; set; }
        public List<Technician> Technicians { get; set; }
        public List<WaterMeter> WaterMeters { get; set; } 

    }
}
