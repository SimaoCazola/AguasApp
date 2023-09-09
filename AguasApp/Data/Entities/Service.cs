using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AguasApp.Data.Entities
{
    public class Service : IEntity
    {
      
        public int Id { get; set; } // Service identifier
        public string Name { get; set; } // Service name
        public double Price { get; set; } // Service price
        public string Description { get; set; } // Service description
        public bool Active { get; set; } // Indicates if the service is active or inactive
        public string Image { get; set; }

        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }


        // Fornecimento de Água Residencial
        //Tratamento de Água: 
        //Manutenção de Redes de Distribuição: 
        //Reparos e Intervenções:
        //Atendimento ao Cliente:
        //
        //
    }
}
