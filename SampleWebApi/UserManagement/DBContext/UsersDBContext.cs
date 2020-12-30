using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.DBContext
{


    // all user tables 
    public class UsersDBContext:IdentityDbContext
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options):base(options)
        { 
                
        }
    }
}
