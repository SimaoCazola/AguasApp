using AguasApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AguasApp.Models
{
    // Nesta contem a propriedade da Image
    public class ProductViewModel:Product
    {
        [Display(Name = "Image")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
