using CQRS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.DAL
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) :base (options)
        {

        }

        public DbSet<Product> Products{ get; set; } 
        public DbSet<Category> Categories { get; set; } 
    }
}
