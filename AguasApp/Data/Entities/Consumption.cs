using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class Consumption: IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Scalation*")]
        public Scalation Scalation { get; set; }

        public string Descriptions { get; set; }

        //[Required]
        [Display(Name = "Unit Price*")]
        public Price Price { get; set; }


        //[Required]
        [Display(Name = "Volume*")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Volume { get; set; }

        //[Required]
        [Display(Name = "Total Amount*")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Value => (decimal)Price * (decimal)Volume;
      

        [Required]
        [Display(Name = "Today Date*")]
        public DateTime TodayDate=> DateTime.Now;

        [Required]
        [Display(Name = "Last Reading Date*")]
        public DateTime LastReadingDate { get; set; }

        //[Required]
        [Display(Name = "Status*")]
        public Status Status { get; set; }


    }
}
 