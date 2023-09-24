using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class CustomerService : IEntity  // Class "AtendimentoCliente" (CustomerService):
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Name*")]
        public int ServiceId { get; set; } 
        public virtual Service ServiceName { get; set; } 

        [Display(Name = "Today Date ")]
        public DateTime DateTimeOpened = DateTime.Now;  

        [Display(Name = "Sevice Start Date ")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Customer Name*")]
        public string  CustomerName { get; set; }

        [Display(Name = "Customer Adress*")]
        public string CustomerAdress { get; set; }

        [Required]
        [Display(Name = "Nif*")]
        public int Nif { get; set; } 


        [Display(Name = "Customer Phone Number*")]
        public int PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Status*")]
        public Status Status { get; set; }  

       
        [Display(Name = "Technician Name*")]
        public string TechnicianName { get; set; }


        [Display(Name = "Technician Phone*")]
        public int TechnicianPhone { get; set; } 


        [Display(Name = "Water Meter Name*")]
        public string WaterMeterName { get; set; }


        [Display(Name = "Water Meter Number*")]
        public int WaterMeterNumber { get; set; } 


    }
}
