using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can contain {1}Characters length.")]
        [Display(Name = "Full Name*")]
        public string FullName { get; set; }

        //[Required]
        [Display(Name = "Nif*")]
        public int Nif { get; set; }

        //[Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Invoice Number*")]
        public int InvoiceNumber { get; set; }


        [Required]
        [Display(Name = "Scalation*")]
        public Scalation Scalation { get; set; }

        public string Descriptions { get; set; }

        //[Required]
        [Display(Name = "Unit Price*")]
        public Price Price { get; set; }


        //[Required]
        [Display(Name = "Volume*")]
        //[DisplayFormat(DataFormatString = "{0:V2}")]
        public decimal Volume { get; set; }

        //[Required]
        [Display(Name = "Total Amount*")]
        //[DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Value => (decimal)Price * Volume;


        [Required]
        [Display(Name = "Today Date*")]
        public DateTime TodayDate => DateTime.Now;

        [Required]
        [Display(Name = "Reading Date*")]
        public DateTime LastReadingDate { get; set; }


        [Required]
        [Display(Name = "Payment Deadline*")]
        public DateTime DueDate { get; set; }

        [Required]
        [Display(Name = "Payment Status*")]
        public Status Status { get; set; }

        //[Required]
        public int Reference { get; set; }
        public int Entity { get; set; } 

        public User User { get; set; }
    }
}
