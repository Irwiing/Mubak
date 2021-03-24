using System;

namespace Model
{
    public class Sale
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public DateTime DateSale { get; set; }
        public string User { get; set; }
        public string  Items { get; set; }
        public decimal TotalValue { get; set; }
    }
}
