﻿namespace Model
{
    public class ItemProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public decimal UnitaryValue { get; set; }
        public int Amount { get; set; }
        public decimal TotalValue { get; set; }

    }
}
