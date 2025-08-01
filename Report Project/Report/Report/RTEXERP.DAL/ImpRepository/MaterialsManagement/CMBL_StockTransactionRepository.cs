using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.MaterialsManagement;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
   public class CMBL_StockTransactionRepository:GenericRepository<CMBL_StockTransaction>, ICMBL_StockTransactionRepository
    {
        private MaterialsManagementDBContext dbCon;

        public CMBL_StockTransactionRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<UnitDetailsViewModel> GetDocumentTypeWiseRate(int itemid)
        {
            var model = new UnitDetailsViewModel();
            var ItemRateQuery = from stock in dbCon.CMBL_StockTransaction
                                where stock.DocumentTypeID == 10 && stock.ItemID == (long)itemid
                                orderby stock.StockTransactionID descending
                                select stock;
            var itemRateRow = await ItemRateQuery.FirstOrDefaultAsync();
            if (itemRateRow != null)
            {
                model.UnitID = itemRateRow.UserSelectedUnit;
                model.UnitRate = itemRateRow.Rate_WRTbaseUnit;
            }
            else
            {
                model.UnitRate = 0;
            }
             
            //long stockTransactionID =  dbCon.CMBL_StockTransaction.Where(b=>b.DocumentTypeID==10).Max(u => u.StockTransactionID);
            //var obj = await  dbCon.CMBL_StockTransaction.Where(b => b.StockTransactionID == stockTransactionID && b.ItemID== itemid).FirstOrDefaultAsync();

           
            //model.UnitID = obj==null?0:   obj.UserSelectedUnit;
            //model.UnitRate = obj == null ? 0 : obj.Rate_WRTbaseUnit;
            return model;

        }
    }
}
