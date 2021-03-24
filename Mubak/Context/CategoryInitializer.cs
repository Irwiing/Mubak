using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    class CategoryInitializer : DropCreateDatabaseIfModelChanges<CategoryContext>
    {
        protected override void Seed(CategoryContext context)
        {
            var categories = new List<Category>
            {
                new Category{ Id = 1, Description = "Hardwares"},
                new Category{ Id = 2, Description = "Consoles"},
                new Category{ Id = 3, Description = "Jogos"}
            };

            categories.ForEach(category => context.Categories.Add(category));
            context.SaveChanges();
        }
    }
}
