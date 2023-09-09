using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Invoice Number*")]
        public int InvoiceNumber { get; set; }


        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal AmountToPay { get; set; }

        [Required]
        [Display(Name = "Payment Status*")]
        public string PaymentStatus { get; set; }

        [Required]
        [Display(Name = "Custmer*")]
        public Customer AssociatedCustomer { get; set; }
        
    }
}
