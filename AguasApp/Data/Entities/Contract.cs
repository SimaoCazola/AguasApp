using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class Contract: IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Contract Number*")]
        public int ContractNumber { get; set; }
        public string Nif { get; set; }

        [Display(Name = "Customer Name*")]
        public string CustomerName { get; set; }  

        [Required]
        [Display(Name = "Start Date*")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date*")]
        public DateTime EndDate { get; set; }

       
        [Display(Name = "Contrat Duration*")]
        public string ContractDuration { get; set; }

        [Required]
        [Display(Name = "Is Active Fidelization?*")]
        public bool IsActive { get; set; }
    }
}
