using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class LotRepository : ILotRepository
    {
        private readonly AppDbContext _context;
        DataTable dtLot;
        public LotRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void initDT()
        {

            dtLot = new DataTable();
            dtLot.Columns.Add("BranchID", typeof(int));
            dtLot.Columns.Add("OperatorID", typeof(int));
            dtLot.Columns.Add("Title", typeof(string));
            dtLot.Columns.Add("TitleU", typeof(string));
            dtLot.Columns.Add("LotType", typeof(string));
            dtLot.Columns.Add("Number", typeof(string));
            dtLot.Columns.Add("Description", typeof(string));


        }










        //public async Task<string> DeleteLot(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IList<LotVM>> GetAllLot()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<LotVM> GetLotByID(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<string> SaveLot(LotVM lot)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
