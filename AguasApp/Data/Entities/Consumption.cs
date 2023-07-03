using System;

namespace AguasApp.Data.Entities
{
    public class Consumption
    {
        public int Id { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public string Escalation { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public string Descriptions { get; set; }
        
    }
}
 