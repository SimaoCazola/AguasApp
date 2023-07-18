using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class Contract
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Contract Number*")]
        public int ContractNumber { get; set; }

     
        [Display(Name = "Customer Name*")]
        public Customer CustomerName { get; set; }

        [Required]
        [Display(Name = "Start Date*")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date*")]
        public DateTime EndDate { get; set; }


        public double MonthlyValue { get; set; }

        [Required]
        [Display(Name = "Is Active*")]
        public bool IsActive { get; set; }
    }
}
