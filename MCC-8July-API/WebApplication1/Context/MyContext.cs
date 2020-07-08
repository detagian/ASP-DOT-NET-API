using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class MyContext : DbContext
    {
        public MyContext(): base("myConnectionString") { }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}