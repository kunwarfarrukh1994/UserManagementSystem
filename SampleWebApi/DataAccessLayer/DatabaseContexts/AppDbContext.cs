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
            model_builder.Entity<Customers>().HasNoKey().HasIndex(S => S.ID).IsUnique();
            model_builder.Entity<City>().HasNoKey().HasIndex(S => S.ID).IsUnique();



            model_builder.Entity<adAccounts>().HasNoKey();
            model_builder.Entity<adCategoryAccounts>().HasNoKey();
            model_builder.Entity<adControlAccounts>().HasNoKey();
            model_builder.Entity<adFinancialStatementCategories>().HasNoKey();
            model_builder.Entity<adFinancialStatementTypes>().HasNoKey();
            model_builder.Entity<adGroupAccounts>().HasNoKey();
            model_builder.Entity<adMainGroupAccounts>().HasNoKey();
            model_builder.Entity<cdCompanies>().HasNoKey();
            model_builder.Entity<BuisnessNature>().HasNoKey();

            model_builder.Entity<adAccountTypes>().HasNoKey();
            model_builder.Entity<adAccountTransactionTypes>().HasNoKey();


            model_builder.Entity<Adda>().HasNoKey();
            model_builder.Entity<Lot>().HasNoKey();
            model_builder.Entity<GenMain>().HasNoKey();
            model_builder.Entity<GenSub>().HasNoKey();
            model_builder.Entity<Schools>().HasNoKey();
            model_builder.Entity<SaleReturnMain>().HasNoKey();
            model_builder.Entity<SaleReturnSub>().HasNoKey();







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
        public DbSet<Customers> Customers { get; set; }
        public DbSet<City> City { get; set; }


        public DbSet<adAccounts> adAccounts { get; set; }
        public DbSet<adCategoryAccounts> adCategoryAccounts { get; set; }
        public DbSet<adControlAccounts> adControlAccounts { get; set; }
        public DbSet<adFinancialStatementCategories> adFinancialStatementCategories { get; set; }
        public DbSet<adFinancialStatementTypes> adFinancialStatementTypes { get; set; }
        public DbSet<adGroupAccounts> adGroupAccounts { get; set; }
        public DbSet<adMainGroupAccounts> adMainGroupAccounts { get; set; }
        public DbSet<cdCompanies> cdCompanies { get; set; }
        public DbSet<BuisnessNature> BuisnessNature { get; set; }

        public DbSet<adAccountTransactionTypes> adAccountTransactionTypes { get; set; }
        public DbSet<adAccountTypes> adAccountTypes { get; set; }

        public DbSet<Adda> Adda { get; set; }
        public DbSet<Lot> Lot { get; set; }
        public DbSet<GenMain> GenMain { get; set; }
        public DbSet<GenSub> GenSub { get; set; }
        public DbSet<Schools> Schools { get; set; }
        public DbSet<SaleReturnMain> SaleReturnMain { get; set; }
        public DbSet<SaleReturnSub> SaleReturnSub { get; set; }



    }
}
