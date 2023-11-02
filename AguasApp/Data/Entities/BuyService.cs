using System.ComponentModel.DataAnnotations;

namespace AguasApp.Data.Entities
{
    public class BuyService:IEntity
    {
       public int Id { get; set; }
     
       public virtual Service Service { get; set; }
        [Required]
        [Display(Name = "Service List")]
        public int ServiceId { get; set; }
        [Required]
        public string Description { get; set; }
     
        public  string User { get; set; }

        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Adress { get; set; } 
    }

}
   

