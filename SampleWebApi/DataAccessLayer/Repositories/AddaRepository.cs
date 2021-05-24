using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AddaRepository : IAddaRepository
    {
        private readonly AppDbContext _context;
        DataTable dtAdda;
        public AddaRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void initDT()
        {

            dtAdda = new DataTable();
            dtAdda.Columns.Add("Title", typeof(string));
            dtAdda.Columns.Add("TitleU", typeof(string));
            dtAdda.Columns.Add("BranchID", typeof(int));
            dtAdda.Columns.Add("OperatorID", typeof(int));

        }



        //public async Task<string> DeleteAdda(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<AddaVM> GetAddaByID(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IList<AddaVM>> GetAllAdda()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<string> SaveAdda(AddaVM adda)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
