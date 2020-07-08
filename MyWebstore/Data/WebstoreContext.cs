using Microsoft.EntityFrameworkCore;
using MyWebstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebstore.Data
{
    public class WebstoreContext : DbContext
    {
        public WebstoreContext(DbContextOptions<WebstoreContext> options)
            : base(options)
        {
        }

        public DbSet<StoreItem> StoreItem { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
    }
}
