using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ReposiotryInterfaces
{
    public interface IGenericRepository<T> where T:class
    {

        Task<T> CreateEntityAsync(T entity);
        
        Task<T> GetEntityByID(Guid id);



       Task<List<T>> GetAllAsync();

        Task<bool> UpdateEntity(T entity);


        Task<string> DeleteEntity(Guid id);


    }
}
