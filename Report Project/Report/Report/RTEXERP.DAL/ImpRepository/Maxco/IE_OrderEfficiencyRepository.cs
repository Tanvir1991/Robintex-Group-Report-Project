using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class IE_OrderEfficiencyRepository : GenericRepository<IE_OrderEfficiency>, IIE_OrderEfficiencyRepository
    {
        private MaxcoDBContext dbCon;

        public IE_OrderEfficiencyRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<IE_OrderEfficiencyViewModel>GetIEOrderEfficient(int id)
        {
            var obj = await (from oe in dbCon.IE_OrderEfficiency
                              join or in dbCon.Style on oe.OrderID equals or.ID
                              join st in dbCon.Style on oe.StyleID equals st.ID
                              join c in dbCon.Collection on or.CollectionID equals c.ID
                              join b in dbCon.Buyer_Setup on c.BuyerID equals b.ID
                              where oe.ID==id && oe.IsRemoved==false
                              select new IE_OrderEfficiencyViewModel()
                              {
                                  ID = oe.ID,
                                  OrderID = oe.OrderID,
                                  StyleID = oe.StyleID,
                                  LineID = oe.LineID,
                                  OrderNo = or.OrderNo,
                                  StyleName = st.Description,
                                  PantoneNo = oe.PantoneNo,
                                  HourlyTargetProduction = oe.HourlyTargetProduction,
                                  OrderSMV = oe.OrderSMV,
                                  TargetEffiency = oe.TargetEffiency,
                                  Remarks = oe.Remarks,
                                  BuyerID =b.ID,
                                  ReportDateSTR = oe.ReportDate.ToString("dd-MMM-yyyy"),
                                  ReportDate = oe.ReportDate,
                                  LineManpower=oe.LineManpower

                              }).FirstAsync();
            return obj;
        }
        public async Task<List<OrderEfficiencyDataModel>> GetOrderEfficientList(DateTime? dateFrom, DateTime? dateTo, int orderID = 0, int styleID = 0, string pantonNo = null)
        {
           // var presentDate = DateTime.Now.Date;
            var list = await (from oe in dbCon.IE_OrderEfficiency
                              join or in dbCon.Style on oe.OrderID equals or.ID
                              join st in dbCon.Style on oe.StyleID equals st.ID
                             // join p in dbCon.vw_OrderGarmentAssortmentOrder_Pantone on oe.PantoneNo equals p.PantoneNo
                              where (orderID==0|| oe.OrderID==orderID)&&(styleID==0||oe.StyleID==styleID)&&(pantonNo==null||oe.PantoneNo==pantonNo) && 
                              (dateFrom==null || oe.ReportDate.Date >= dateFrom.Value.Date) &&(dateTo==null || oe.ReportDate.Date <= dateTo.Value.Date)   //(oe.CreatedDate.Date >= dateFrom.Date && oe.CreatedDate.Date  <= dateTo.Date) && oe.IsRemoved==false
                              && oe.IsRemoved==false
                              select new OrderEfficiencyDataModel()
                              {
                                  ID=oe.ID,
                                  OrderID=oe.OrderID,
                                  StyleID=oe.StyleID,
                                  LineID=oe.LineID,
                                  OrderNo=or.OrderNo,
                                  StyleName=st.Description,
                                  PantoneNo=oe.PantoneNo,
                                  HourlyTargetProduction=oe.HourlyTargetProduction,
                                  OrderSMV=oe.OrderSMV,
                                  TargetEffiency=oe.TargetEffiency,
                                  Remarks=oe.Remarks,
                                  ManPower=oe.LineManpower,
                                  
                              }).ToListAsync();
            return list;
            //var list = await dbCon.IE_OrderEfficiency.Where(b => (orderID == 0 || b.OrderID == orderID))
            //    .Select(x => new OrderEfficiencyDataModel()
            //    {

            //    }).ToListAsync();
        }

        public async Task<RResult> SaveIEOrderEfficiency(IE_OrderEfficiency model)
        {
            var rResult = new RResult();
            try
            {
                if (model.ID>0)
                {
                    dbCon.IE_OrderEfficiency.Update(model);
                    rResult.message = ReturnMessage.UpdateMessage;
                    rResult.statusCode = model.ID;
                }
                else
                {
                    model.CreatedDate = DateTime.Now;
                    model.IsRemoved = false;
                    await dbCon.IE_OrderEfficiency.AddAsync(model);
                    rResult.message = ReturnMessage.InsertMessage;
                }
                await dbCon.SaveChangesAsync();

               
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            rResult.result = 1;
           
            return rResult;

        }

        public async Task<IE_OrderEfficiency>GetOrderEfficientByID(int ID)
        {
            var obj = await dbCon.IE_OrderEfficiency.Where(b => b.ID == ID).FirstAsync();
            return obj;
        }

        public async Task<RResult>Remove(int ID)
        {
            var rResult = new RResult();
            try
            {
                var obj = await dbCon.IE_OrderEfficiency.Where(b => b.ID == ID).FirstAsync();
                obj.IsRemoved = true;
                dbCon.IE_OrderEfficiency.Update(obj);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}
