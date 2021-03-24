using System.Data.Entity;
using Model;

namespace Context
{
    public class ItemProductContext : DbContext
    {
        public ItemProductContext() : base("ItemProductContext")
        {

        }

        public DbSet<ItemProduct> ItemsProducts { set; get; }
    }
}
