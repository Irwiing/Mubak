using Model;
using System.Collections.Generic;
using System.Data.Entity;


namespace Context
{
    public class ItemProductInitializer : DropCreateDatabaseIfModelChanges<ItemProductContext>
    {
        protected override void Seed(ItemProductContext context)
        {
            var itemProducts = new List<ItemProduct>();

            itemProducts.ForEach(ip => context.ItemsProducts.Add(ip));
            context.SaveChanges();
        }
    }
}
