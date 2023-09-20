using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public enum Scalation
    {
        [Display(Name = "Scalation 1 is 5m³ = 0.30 USD ")]
        FirstScalation,

        [Display(Name = "Scalation 2 is up 5m³ to 15m³= 0.80 USD  ")]
        SecondScalation,

        [Display(Name = "Scalation 3 is up 15m³ to 25m³= 1.20 USD ")]
        ThirdScalation,

        [Display(Name = "Scalation 3 is up 25m³= 1.60 USD ")]
        ForthScalation

    }
}
