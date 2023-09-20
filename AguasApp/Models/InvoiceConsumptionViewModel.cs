using AguasApp.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AguasApp.Models
{
    public class InvoiceConsumptionViewModel
    {
        public Invoice Invoice { get; set; }
        public Customer Customer { get; set; } 

        public List<Customer> Customers { get; set; } 

    } 
}
