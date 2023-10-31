using AguasApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using AguasApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AguasApp.Data
{
    public class DataContext: IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; } 

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

        public DbSet<Order> Orders { get; set; } // Tabela dos Order

        public DbSet<OrderDetail> OrderDetails { get; set; } // Tabela dos OrderDetail

        public DbSet<OrderDetailTemp> OrderDetailsTemp { get; set; } // Tabela dos OrderDetailTemp

        public DbSet<Cart> Carts { get; set; }

        public DbSet<BuyService> BuyServices { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<AguasApp.Models.ProductSitesViewModel> ProductSitesViewModel { get; set; }

        public DbSet<AguasApp.Data.Entities.Service> Service { get; set; }

        public DbSet<AguasApp.Models.ProductViewModel> ProductViewModel { get; set; }

    }
}
