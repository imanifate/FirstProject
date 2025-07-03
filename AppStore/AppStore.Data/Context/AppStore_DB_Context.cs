using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Data.Context
{
    public class AppStore_DB_Context : DbContext
    {
        public AppStore_DB_Context(DbContextOptions<AppStore_DB_Context> option):base(option) 
        { 

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductSubGroup> ProductSubGroups{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
