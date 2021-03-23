using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ItemProduct
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal InitaryValue { get; set; }
        public int Amount { get; set; }
        public decimal TotalValue { get; set; }

    }
}
