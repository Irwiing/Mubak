using System;
using System.Collections.Generic;

namespace Model
{
    public class Sale
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public DateTime DateSale { get; set; }
        public string Costumer { get; set; }
        public List<ItemProduct>  Items { get; set; }
        public decimal TotalValue { get; set; }
    }
}
