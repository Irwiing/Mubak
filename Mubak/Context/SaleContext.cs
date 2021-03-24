using Model;
using System.Data.Entity;

namespace Context
{
    public class SaleContext : DbContext
    {
        public SaleContext() : base("MubakContext")
        {

        }

        public DbSet<Sale> Sales { get; set; }
    }
}
