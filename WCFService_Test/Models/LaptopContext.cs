using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace WCFService_Test.Models
{
    public class LaptopContext : DbContext
    {
        public LaptopContext() : base("EAPWCFTest") { }

        public DbSet<Models.Laptop> Laptops { get; set; }
    }
}