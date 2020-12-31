using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.UserModels;

namespace UserManagement.DBContext
{


    // all user tables 
    public class UsersDBContext:IdentityDbContext<ApplicationUser>
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options):base(options)
        { 
                
        }
    }
}
