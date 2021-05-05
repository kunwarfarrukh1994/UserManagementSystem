using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private DbSet<T> table;

        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            this._context = context;
            this.table=this._context.Set<T>();
        }



        public async Task<T> CreateEntityAsync(T entity)
        {
           
                var savedEntity = await this.table.AddAsync(entity);
                this._context.SaveChanges();
                return savedEntity.Entity;
      
        }



        public async Task<T> GetEntityByID(Guid id)
        {

            return await this.table.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.table.ToListAsync<T>();

        }

        public async  Task<bool> UpdateEntity(T entity)
        {

            try
            {

                this.table.Update(entity);
                this._context.Entry(entity).State = EntityState.Modified;
               await  this._context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) {

                throw ex;
            }
          

        }

        public async Task<string>  DeleteEntity(Guid id)
        {
           T record = await this.table.FindAsync(id);

            if (record == null)
            {
                return "NotFound";
            }
            else {
                this.table.Remove(record);
                this._context.SaveChanges();

                return "Deleted";
            }
            
        }


       
    }
}
