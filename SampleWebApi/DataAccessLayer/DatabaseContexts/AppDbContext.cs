using BussinessModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { 


           
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
