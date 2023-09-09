namespace AguasApp.Data.Entities
{
    public class Cart:IEntity
    {
        public int Id { get; set; }
       public Product Product { get; set; }
    }
}
