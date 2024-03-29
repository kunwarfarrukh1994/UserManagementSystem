﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DBContext;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.UserModels;

namespace UserManagement.Services
{
    public class DbLogger:IDbLogger
    {
        private readonly UsersDBContext _dbContext;
        public DbLogger(UsersDBContext context)
        {
            this._dbContext = context;
        }

        public async Task LogToDB(LogApiError error)
        {
          //  await this._dbContext.Database.RollbackTransactionAsync();

            this._dbContext.LogApiErrors.Add(error);
            //this._dbContext.Database.AutoTransactionsEnabled = true;

            //var uu = new ApplicationUser();
            //uu.Address = "llllllllllllllll";
            //uu.UserName = "llllllllllllllllllll";
            //uu.Email = "llllllllllllllllll";
            //this._dbContext.Users.Add(uu);
            this._dbContext.SaveChanges();        
        }

        public async void ROLLBACK_Transaction()
        {
            await this._dbContext.Database.CurrentTransaction.RollbackAsync(); ;
        
        }
    }
}
