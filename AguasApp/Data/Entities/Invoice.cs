using System;

namespace AguasApp.Data.Entities
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public DateTime IssuanceDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Volume { get; set; }
        public double UnitPrice { get; set; }
        public double Amount { get; set; }
        public string Escalation { get; set; }
        public string Description { get; set; }
        // dados de pagamentos 
        public string Entity { get; set; }
        public string Reference { get; set; }
        public string PaymentAmount { get; set; }
    }
}
