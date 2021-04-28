using BussinessModels;
using BussinessModels.DBModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder model_builder)
        {
            base.OnModelCreating(model_builder);
            model_builder.Entity<SaleSub>().HasNoKey();
            model_builder.Entity<SaleMain>().HasNoKey();

            model_builder.Entity<SaleSubWarehouse>().HasNoKey();

        }


        public DbSet<SaleSub> SaleSubs { get; set; }
        public DbSet<SaleMain> SaleMains { get; set; }
        public DbSet<SaleSubWarehouse> SaleSubWarehouses { get; set; }

    }
}
