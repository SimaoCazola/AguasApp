using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class CustomerService  // Class "AtendimentoCliente" (CustomerService):
    {
        public int Id { get; set; }

        public DateTime DateTimeOpened { get; set; }

        public Customer AssociatedCustomer { get; set; }

        [Required]
        [Display(Name = "Problem Details*")]
        public string ProblemDescription { get; set; }

        [Required]
        [Display(Name = "Status*")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Handler*")]
        public string Handler { get; set; }
    }
}
