using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public enum Price
    {
        [Display(Name = "0.30")]
        FirstScalation,

        [Display(Name = "0.80")]
        SecondScalation,

        [Display(Name = "1.20")]
        ThirdScalation,

        [Display(Name = "1.60")]
        ForthScalation
    }
}
