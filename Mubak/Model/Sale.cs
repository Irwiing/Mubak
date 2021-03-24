using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PaymentType { get; set; }

        public DateTime DateSale { get; set; }

        public string Costumer { get; set; }

        public List<ItemProduct> Items { get; set; }

        public decimal TotalValue { get; set; }

    }
}
