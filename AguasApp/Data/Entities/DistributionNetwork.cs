using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public class DistributionNetwork  //Class "RedeDistribuição" (DistributionNetwork):
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Is Active*")]
        public bool IsActive { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Technician Technician { get; set; }

        public WaterMeter WaterMeter { get; set; }

    }
}
