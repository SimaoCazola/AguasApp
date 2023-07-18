using AguasApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AguasApp.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Consumption> Consumptions { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerService> CustomerServices { get; set; }

        public DbSet<DistributionNetwork> DistributionNetworks { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<MeterReading> MeterReadings { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Technician> Technicians { get; set; }

        public DbSet<WaterMeter> WaterMeters { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

    }
}
