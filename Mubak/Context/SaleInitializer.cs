using Model;
using System;
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
                    Items = new List<ItemProduct>
                    {
                        new ItemProduct
                        {
                            Id = 1,
                            Product = new Product{
                                Id = 1,
                                Description = "Placa de vídeo"
                            },  
                            UnitaryValue = 15,
                            Amount = 2,
                            TotalValue = 30
                        },
                    },
                    Costumer = "User",
                    TotalValue = 10,
                    DateSale = DateTime.Now

                },
                new Sale{
                    Id = 2,
                    PaymentType = "boleto",
                    Items = "item",
                    User = "User",
                    TotalValue = 10,
                    DateSale = DateTime.Now

                }
            };

            sales.ForEach(s => context.Sales.Add(s));
            context.SaveChanges();
        }
    }
}
