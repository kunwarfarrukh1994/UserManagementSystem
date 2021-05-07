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

            model_builder.HasDefaultSchema("dbo");

            model_builder.Entity<Agents>().HasNoKey().HasIndex(S => S.ID).IsUnique();
            model_builder.Entity<CodeCodingMain>().HasNoKey().HasIndex(S => S.ID).IsUnique();
            model_builder.Entity<CodeCodingProduction>().HasNoKey().HasIndex(S => S.ID).IsUnique();
            model_builder.Entity<CodeCodingWarehouse>().HasNoKey().HasIndex(S => S.ID).IsUnique();

            model_builder.Entity<GoDown>().HasNoKey().HasIndex(S => S.ID).IsUnique();
            model_builder.Entity<Pandi>().HasNoKey().HasIndex(S => S.ID).IsUnique();

            model_builder.Entity<SaleMain>().HasNoKey().HasIndex(S => S.ID).IsUnique();
            model_builder.Entity<SaleSub>().HasNoKey().HasIndex(S=> S.ID).IsUnique();
            model_builder.Entity<SaleSubWarehouse>().HasNoKey().HasIndex(S => S.ID).IsUnique();
            model_builder.Entity<SalesOutSourceItems>().HasNoKey().HasIndex(S => S.ID).IsUnique();

            model_builder.Entity<SaleParty>().HasNoKey().HasIndex(S => S.ID).IsUnique();


            model_builder.Entity<SubAccount>().HasNoKey().HasIndex(S => S.ID).IsUnique();
            




        }

        public DbSet<Agents> Agents { get; set; }
        public DbSet<CodeCodingProduction> CodeCodingProduction { get; set; }
        public DbSet<CodeCodingMain> CodeCodingMain { get; set; }
        public DbSet<CodeCodingWarehouse> CodeCodingWarehouse { get; set; }
        public DbSet<GoDown> GoDown { get; set; }
        public DbSet<Pandi> Pandi { get; set; }
        public DbSet<SaleSub> SaleSub { get; set; }
        public DbSet<SaleMain> SaleMain { get; set; }
        public DbSet<SaleSubWarehouse> SaleSubWarehouse { get; set; }
        public DbSet<SalesOutSourceItems> SalesOutSourceItems { get; set; }


        public DbSet<SaleParty> SaleParty  { get; set; }
        public DbSet<SubAccount> subAccount { get; set; }

    }
}
