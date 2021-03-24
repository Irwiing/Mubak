using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    public class CategoryContext : DbContext
    {
        public CategoryContext() : base("MubakContext")
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}