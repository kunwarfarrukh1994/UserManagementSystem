using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.UserModels;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Diagnostics;
using UserManagement.Models;

namespace UserManagement.DBContext
{


    // all user tables 
    public class UsersDBContext:IdentityDbContext<ApplicationUser>
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options):base(options)
        {

           // this.ChangeTracker.LazyLoadingEnabled = false;
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
         
           
        }
        public DbSet<LogApiError> LogApiErrors { get; set; }
    }
}
