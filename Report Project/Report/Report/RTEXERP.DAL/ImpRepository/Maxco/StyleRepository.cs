using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class StyleRepository : GenericRepository<Style>, IStyleRepository
    {
        private MaxcoDBContext dbCon;
        public StyleRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLBuyerWiseOrder(int BuyerID, DateTime? OrderCreateionFrom, DateTime? OrderCreationTo, string Predict = null)
        {
            List<int?> IgnoreOrder = new List<int?> { 0, 1, 95, 10 };
            var orderList = from s in dbCon.Style
                            join c in dbCon.Collection on s.CollectionID equals c.ID
                            where (s.OrderNo.Length > 1 && !IgnoreOrder.Contains(s.Status) && (BuyerID == 0 || c.BuyerID == BuyerID))
                            select (new
                            {
                                Text = s.OrderNo.Trim(),
                                Value = s.ID.ToString(),
                                CreateionDate = s.CreationDate != null ? s.CreationDate.Value.Date : DateTime.Now.Date
                            });
            if (OrderCreateionFrom.HasValue == true && OrderCreationTo.HasValue == true)
            {
                orderList = orderList.Where(b => b.CreateionDate >= OrderCreateionFrom.Value.Date && b.CreateionDate <= OrderCreationTo.Value.Date);
            }
            if (Predict != null && Predict.Length > 0)
            {
                orderList = orderList.Where(b => b.Text.Contains(Predict));
            }
            var returnList = await orderList.Select(b => new SelectListItem
            {
                Text = b.Text,
                Value = b.Value
            }).ToListAsync();
            return returnList;
        }

        public async Task<List<SelectListItem>> DDLOrderWiseStyle(int OrderID)
        {
            var styleList = await dbCon.Style
                         .Where(b => b.ParentID == OrderID)
                           .Select(b => new SelectListItem
                           {
                               Text = b.Description.Trim(),
                               Value = b.ID.ToString()
                           }).ToListAsync();
            return styleList;
        }
        public async Task<List<SelectListItem>> DDLOrderWiseStyleGroup(int OrderID)
        {
            var styleList = await dbCon.Style
             .Where(w => w.ParentID == OrderID && w.Description.Length>0 && w.Status>0)
             .GroupBy(b=>b.Description.Trim())
               .Select(s => new SelectListItem
               {
                   Text = s.Key.Trim(),
                   Value = s.Min(m=>m.ID).ToString()
               }).ToListAsync();
            return styleList;
        }

        public async Task<List<BasicModel>> GetOrderNumbers(string Predict)
        {
            var orderList = await dbCon.Style.Where(b => b.Status != 0
                                           && b.OrderNo.Length > 0
                                           && b.OrderNo.Contains(Predict))
                                  .Take(50)
                                  .Select(b => new BasicModel
                                  {
                                      Description = b.OrderNo.Trim(),
                                      ID = Convert.ToInt32(b.ID)
                                  })
                                  .ToListAsync();
            return orderList;
        }

        public async Task<List<OrderTotalHistoryViewModel>> GetOrderTotalHistory(string OrderID, DateTime UpToDate)
        {
            var orderList = new List<OrderTotalHistoryViewModel>();
            try
            {
                //await dbCon.LoadStoredProc("ajt.usp_OrderTotalHistory")
                await dbCon.LoadStoredProc("rpt.GetOrderFabricHistory")
                             .WithSqlParam("OrderString", OrderID)
                              .WithSqlParam("UpToDate", UpToDate)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 orderList = handler.ReadToList<OrderTotalHistoryViewModel>() as List<OrderTotalHistoryViewModel>;
                             });
                return orderList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<StyleVM> GetStyleInfo(long ID)
        {
            var data = await dbCon.Style.Where(b => b.ID == ID)
               .Select(s => new StyleVM
               {
                   ID = s.ID,
                   Description =s.Description.Trim(),
                   CollectionID = s.CollectionID,
                   Status = s.Status,
                   CreationDate = s.CreationDate,
                   OrderNo = s.OrderNo.Trim(),
                   ParentID = s.ParentID,
                   
               }).FirstAsync();
            return data;
        }

        public async Task<List<SelectListItem>> DDLOrderNumbers(int fromLastDurationInMonths=24)
        {
            var toDate = DateTime.Now;
            var dateFrom = toDate.AddMonths((-1) * fromLastDurationInMonths);

            var orderList = await dbCon.Style.Where(b => b.Status != 0
                                           && b.OrderNo.Length > 0
                                           && !b.OrderNo.Contains("sa")
                                           && b.CreationDate>=dateFrom && b.CreationDate<=toDate)                                  
                                  .Select(b => new SelectListItem
                                  {
                                      Text = b.OrderNo.Trim(),
                                      Value = b.ID.ToString()
                                  })
                                  .ToListAsync();
            return orderList;
        }
    }
}
