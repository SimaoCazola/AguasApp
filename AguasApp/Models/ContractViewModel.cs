using AguasApp.Data.Entities;
using System.Collections.Generic;

namespace AguasApp.Models
{
    public class ContractViewModel
    {
        public Contract Contract { get; set; } 
        public Customer Customer { get; set; }
       

        public List<Customer> Customers { get; set; }
  
    }
}
