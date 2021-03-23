using Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Context
{
    public class SaleInitializer : DropCreateDatabaseIfModelChanges<SaleContext>
    {
        protected override void Seed(SaleContext context)
        {
            var sales = new List<Sale>
            {
                new Sale{
                    Id = 1,
                    PaymentType = "pix",

                },
                new Sale{
                    Id = 2,
                    PaymentType = "boleto",

                },
            };

            sales.ForEach(s => context.Sales.Add(s));
            context.SaveChanges();
        }
    }
}
