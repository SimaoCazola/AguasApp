using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AguasApp.Data.Entities
{
    public enum Status
    {
        [Display(Name = "Open")]
        Open,

        [Display(Name = "Pending")]
        Pending,

        [Display(Name = "Closed")]
        Closed,

        [Display(Name = "On Going")]
        OnGoing,

        [Display(Name = "Delaying")]
        Delaying

    }
}
