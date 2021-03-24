﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("MubakContext")
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
