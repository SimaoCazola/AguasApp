using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AguasApp.Data.Entities
{
    public class Service : IEntity
    {
      
        public int Id { get; set; } // Service identifier
        public string Name { get; set; } // Service name
        public string Description { get; set; } // Service description
        public string Image { get; set; }
        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
