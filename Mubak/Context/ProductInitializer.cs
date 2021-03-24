using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    class ProductInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var products = new List<Product>
            {
                new Product{Id = 1, Description = "Memoria Ram", Brand = "UltraY", Model = "Furioso 8GB", UnitaryPrice = 250.00M},
                new Product{Id = 2, Description = "Placa Mae", Brand = "Erasus", Model = "M87TT32 USB 8.0", UnitaryPrice = 500.00M},
                new Product{Id = 3, Description = "Placa de Video", Brand = "LVidia", Model = "JForce RTX 123124 32GB VRam", UnitaryPrice = 15000.00M}
            };

            products.ForEach(product => context.Products.Add(product));
            context.SaveChanges();
        }
    }
}