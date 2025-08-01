using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel.MerchandisingCost;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco.SPModels;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class MaxcoReportRepository : IMaxcoReportRepository
    {
        private readonly MaxcoDBContext maxcoDB;
        public MaxcoReportRepository(MaxcoDBContext _maxcoDB)
        {
            maxcoDB = _maxcoDB;
        }
        public async Task<OrderSheetReport> OrderSheetReportData(int CurrentVersionID)
        {
            var itemList = new OrderSheetReport();
            try
            {


                await maxcoDB.LoadStoredProc("rpt.OSFinalSummary")
                             .WithSqlParam("CurrentVersionID", CurrentVersionID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 var os = handler.ReadToList<OSFinalSummary>() as List<OSFinalSummary>;
                                 itemList.OSFinalSummary = os.FirstOrDefault();

                             });

                await maxcoDB.LoadStoredProc("rpt.OSFabricPart")
                             .WithSqlParam("CurrentVersionID", CurrentVersionID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList.OSFabricPart = handler.ReadToList<OSFabricPart>() as List<OSFabricPart>;


                             });

                await maxcoDB.LoadStoredProc("rpt.OSTrimPart")
                             .WithSqlParam("CurrentVersionID", CurrentVersionID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList.OSTrimPart = handler.ReadToList<OSTrimPart>() as List<OSTrimPart>;


                             });

                var fabricCosting = await this.MerchandisingAssessmentFabricCost(itemList.OSFinalSummary.OrderString);
                var trimCosting = await this.MerchandisingAssessmentIndirectCost(itemList.OSFinalSummary.OrderString);
                itemList.MerchandisingAssessmentFabricCost = fabricCosting;
                itemList.MerchandisingAssessmentIndirectCost = trimCosting;

                /*
                await maxcoDB.LoadStoredProc("rpt.MerchandisingAssessmentFabricCost")
                     .WithSqlParam("CurrentVersionID", CurrentVersionID)
                     .ExecuteStoredProcAsync((handler) =>
                     {
                         itemList.OSTrimPart = handler.ReadToList<OSTrimPart>() as List<OSTrimPart>; 
                     });

                await maxcoDB.LoadStoredProc("rpt.OSTrimPart")
                     .WithSqlParam("CurrentVersionID", CurrentVersionID)
                     .ExecuteStoredProcAsync((handler) =>
                     {
                         itemList.OSTrimPart = handler.ReadToList<OSTrimPart>() as List<OSTrimPart>; 
                     });
                */
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<OrderSheetVersionSPModel>> GetOrderVersion(string OrderNo)
        {
            List<OrderSheetVersionSPModel> data = new List<OrderSheetVersionSPModel>();
            try
            {
                await maxcoDB.LoadStoredProc("ajt.GetOrderVersion")
                         .WithSqlParam("OrderNo", OrderNo)
                         .ExecuteStoredProcAsync((handler) =>
                         {
                             data = handler.ReadToList<OrderSheetVersionSPModel>() as List<OrderSheetVersionSPModel>;


                         });
            }
            catch (Exception e)
            {
                throw new Exception("Not Found");
            }
            return data;
        }

        public async Task<List<MerchandisingAssessmentFabricCost>> MerchandisingAssessmentFabricCost(string OrderNo)
        {
            List<MerchandisingAssessmentFabricCost> data = new List<MerchandisingAssessmentFabricCost>();
            try
            {
                var orderCosting = await maxcoDB.MAC_OrderCostingInfo.Where(b => b.OrderNo == OrderNo
                                                    && b.IsRemvoed == false
                                                    && b.IsActive == true).FirstOrDefaultAsync();
                if (orderCosting != null)
                {
                    await maxcoDB.LoadStoredProc("rpt.MerchandisingAssessmentFabricCost")
                             .WithSqlParam("OrderCostingID", orderCosting.ID)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 data = handler.ReadToList<MerchandisingAssessmentFabricCost>() as List<MerchandisingAssessmentFabricCost>;


                             });
                }
            }
            catch (Exception e)
            {
                throw new Exception("Not Found");
            }
            return data;
        }

        public async Task<List<MerchandisingAssessmentIndirectCost>> MerchandisingAssessmentIndirectCost(string OrderNo)
        {
            List<MerchandisingAssessmentIndirectCost> data = new List<MerchandisingAssessmentIndirectCost>();
            try
            {
                var orderCosting = await maxcoDB.MAC_OrderCostingInfo.Where(b => b.OrderNo == OrderNo && b.IsRemvoed == false && b.IsActive == true).FirstOrDefaultAsync();
                if (orderCosting != null)
                {
                    await maxcoDB.LoadStoredProc("rpt.MerchandisingAssessmentIndirectCost")
                         .WithSqlParam("OrderCostingID", orderCosting.ID)

                         .ExecuteStoredProcAsync((handler) =>
                         {
                             data = handler.ReadToList<MerchandisingAssessmentIndirectCost>() as List<MerchandisingAssessmentIndirectCost>;


                         });
                }
            }
            catch (Exception e)
            {
                throw new Exception("Not Found");
            }
            return data;
        }


        public async Task<OrderSheetFirstAndLastVersionSPModel> GetOSVersionDifferenceInfo(int OrderID, int BuyerID)
        {
            List<OrderSheetFirstAndLastVersionSPModel> data = new List<OrderSheetFirstAndLastVersionSPModel>();
            try
            {

                await maxcoDB.LoadStoredProc("ajt.USP_OrderSheetFirstAndLastVersion")
                     .WithSqlParam("OrderID", OrderID)
                     .WithSqlParam("BuyerID", BuyerID)
                    .ExecuteStoredProcAsync((handler) =>
                     {
                         data = handler.ReadToList<OrderSheetFirstAndLastVersionSPModel>() as List<OrderSheetFirstAndLastVersionSPModel>;
                     });
            }
            catch (Exception e)
            {
                throw new Exception("Not Found");
            }
            return data.First();
        }
    }
}
