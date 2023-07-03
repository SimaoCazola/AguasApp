using AguasApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AguasApp.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Meter> Meters { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

    }
}
