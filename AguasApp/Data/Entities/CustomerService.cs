using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class CustomerService : IEntity  // Class "AtendimentoCliente" (CustomerService):
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Details*")]
        public string ServiceDescription { get; set; }

        [Display(Name = "Today Date ")]
        public DateTime DateTimeOpened { get; set; }

        [Display(Name = "Sevice Start Date ")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Customer Name*")]
        public int CustomerNameId { get; set; }
        public virtual Customer CustomerName { get; set; }

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

       
        [Display(Name = "Technician*")]
        public int TechnicianId { get; set; } 
        public virtual Technician Technician { get; set; }

        
        [Display(Name = "Water Meter*")]
        public int WaterMeterId { get; set; } 
        public virtual WaterMeter WaterMeter { get; set; } 


    }
}
