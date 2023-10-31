namespace AguasApp.Data.Entities
{
    public class BuyService:IEntity
    {
       public int Id { get; set; } 
       public virtual Service Service { get; set; }
       public int ServiceId { get; set; }  
       public string Description { get; set; }
       public  string User { get; set; }
       public string Mobile { get; set; }
       public string Email { get; set; }
       public string Adress { get; set; } 
    }

}
   

