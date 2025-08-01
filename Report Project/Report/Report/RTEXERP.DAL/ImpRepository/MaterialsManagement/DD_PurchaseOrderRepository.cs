using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using Snickler.EFCore;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class DD_PurchaseOrderRepository : GenericRepository<DD_PurchaseOrder>, IDD_PurchaseOrderRepository
    {
        private MaterialsManagementDBContext dbCon;
        public DD_PurchaseOrderRepository(MaterialsManagementDBContext context)
              : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLPurchaseOrder(int OrderID, DateTime? PODateFrom = null, DateTime? PODateTo = null)
        {
            var query = from m in dbCon.DD_PurchaseOrder
                        join dm in dbCon.DD_POItemMaster on m.ID equals dm.PurchaseOrderID
                        select new
                        {
                            POID = m.ID,
                            PONO = m.PurchaseOrderNo,
                            PODate = m.CreationDate,
                            OrderID = dm.OrderID
                        };
            if (OrderID > 0)
            {
                query = query.Where(b => b.OrderID == OrderID);
            }
            if(PODateFrom!=null && PODateFrom.HasValue==true && PODateTo != null && PODateTo.HasValue == true)
            {
                query = query.Where(b => b.PODate.Value.Date >= PODateFrom.Value.Date && b.PODate.Value.Date <= PODateTo.Value.Date);
            }
            var dropdowndata =  query
                .Select(s=>new SelectListItem { 
                    Text = s.PONO,
                    Value = s.POID.ToString()
                }).Distinct();

            return await dropdowndata.ToListAsync();
        }

        public async Task<List<SelectListItem>> DDLPurchaseOrderStatus()
        {
            var data = dbCon.DD_POStatus_Setup.Select(s => new SelectListItem
            {
                Text = s.Description.Trim(),
                Value = s.ID.ToString()
            });

            return await data.ToListAsync();
        }

        public async Task<List<DD_PO_PurchaseOrderDetailsInfoSPModel>> GetDD_PO_PurchaseOrderDetailsInfo(int POID)
        {
            var itemList = new List<DD_PO_PurchaseOrderDetailsInfoSPModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.GetDD_PO_PurchaseOrderDetailsInfo")
                                .WithSqlParam("POID", POID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<DD_PO_PurchaseOrderDetailsInfoSPModel>() as List<DD_PO_PurchaseOrderDetailsInfoSPModel>;
                             });

                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<DD_PO_PurchaseOrderInfoSPModel> GetDD_PO_PurchaseOrderInfo(int POID)
        {
            var itemList = new List<DD_PO_PurchaseOrderInfoSPModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.GetDD_PO_PurchaseOrderInfo")
                             .WithSqlParam("POID", POID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<DD_PO_PurchaseOrderInfoSPModel>() as List<DD_PO_PurchaseOrderInfoSPModel>;
                             });
                return itemList.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<GetOrderPOListSPModel>> GetOrderPOList(int OrderID = 0, int POID = 0, DateTime? PODateFrom = null, DateTime? PODateTo = null, int StatusID = 0)
        {
            var itemList = new List<GetOrderPOListSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.GetOrderPOList")
                             .WithSqlParam("OrderID", OrderID)
                             .WithSqlParam("POID", POID)
                             .WithSqlParam("PODateFrom", PODateFrom)
                             .WithSqlParam("PODateTo", PODateTo)
                             .WithSqlParam("StatusID", StatusID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<GetOrderPOListSPModel>() as List<GetOrderPOListSPModel>;
                             });
                 
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
