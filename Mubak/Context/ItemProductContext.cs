using System.Data.Entity;
using Model;

namespace Context
{
    public class ItemProductContext : DbContext
    {
        public ItemProductContext() : base("MubakContext")
        {

        }

        public DbSet<ItemProduct> ItemsProducts { set; get; }
    }
}
