using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class Report //Class "Relatório" (Report):
    {
        public int Id { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Creation Date*")]
        public DateTime CreationDate { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Report Type*")]
        public string ReportType { get; set; }

        [Required]
        public string Filters { get; set; }

        [Required]
        [Display(Name = "Total Liters*")]
        public double TotalLitersConsumed { get; set; }

        [Required]
        public double Revenue { get; set; }

        [Required]
        [Display(Name = "All Customers*")]
        public int NumberOfCustomersServed { get; set; }

    }
}
