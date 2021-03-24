using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    class PaymentContext : DbContext
    {
        public PaymentContext() : base ("MubakContext")
        {

        }
        public DbSet<Payment> Payments { get; set; }
    }
}
