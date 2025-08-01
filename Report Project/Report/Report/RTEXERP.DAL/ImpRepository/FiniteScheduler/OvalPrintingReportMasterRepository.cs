using AutoMapper;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
   public class OvalPrintingReportMasterRepository:GenericRepository<OvalPrintingReportMaster>, IOvalPrintingReportMasterRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private IMapper mapper;
        public OvalPrintingReportMasterRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }

        public async Task<OvalPrintingReportMasterViewModel> GetOvalPrintingInformation(DateTime ReportDate, int ID = 0,DateTime? ReportDateTo=null)
        {
            OvalPrintingReportMasterViewModel model = new OvalPrintingReportMasterViewModel();
            try
            {
                
                var data =await (from om in dbCon.OvalPrintingReportMaster
                            join od in dbCon.OvalPrintingReportDetails on om.ID equals od.MasterID
                            where (om.ReportDate.Date >= ReportDate.Date && om.ReportDate.Date <= ReportDateTo.Value.Date) && om.IsRemoved==false && od.IsRemoved==false
                            && (ID == 0 || om.ID == ID)
                            select new OvalPrintingReportDetailsViewModel
                            {
                                MachineCode = od.MachineCode,
                                BuyerName = od.BuyerName,
                                OrderNo = od.OrderNo,
                                StyleName = od.StyleName,
                                Color = od.Color,
                                PrintItem = od.PrintItem,
                                OrderQty = od.OrderQty,
                                ProductionQty = od.ProductionQty,
                                PrintPricePerDozen = od.PrintPricePerDozen,
                                CostPerDozen = od.CostPerDozen,
                                ProfitPerDozen = od.ProfitPerDozen,
                                TotalPrice = od.TotalPrice,
                                TotalCost = od.TotalCost,
                                TotalProfit = od.TotalProfit,
                                TotalPriceBDT = od.TotalPriceBDT,
                                TotalCostBDT = od.TotalCostBDT,
                                TotalProfitBDT = od.TotalProfitBDT
                            }).ToListAsync();
                model.OvalPrintingReportDetails = data;
                model.ReportDateMsg = $"Date From :{ReportDate.ToString("dd-MMM-yyyy")} To {ReportDateTo.Value.ToString("dd-MMM-yyyy")}";
                model.ReportDate = ReportDate;

                return model;

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<RResult> OvalPrintingReportMasterSave(OvalPrintingReportMasterViewModel OvalPrintingReportMaster)
        {
            RResult rResult = new RResult();
            try
            {
                var entity = mapper.Map<OvalPrintingReportMasterViewModel, OvalPrintingReportMaster>(OvalPrintingReportMaster);

                var findExistingDataSameDate =await dbCon.OvalPrintingReportMaster
                      .Include(b => b.OvalPrintingReportDetails)
                      .FirstOrDefaultAsync(b => b.IsRemoved == false && b.ReportDate == entity.ReportDate);

                if (findExistingDataSameDate != null)
                {
                    findExistingDataSameDate.IsRemoved = true;
                    findExistingDataSameDate.UpdateDate = DateTime.Now;
                    dbCon.Update(findExistingDataSameDate);

                    findExistingDataSameDate.OvalPrintingReportDetails.ToList().ForEach(b => { b.IsRemoved = true;b.UpdateDate = DateTime.Now; });
                    dbCon.UpdateRange(findExistingDataSameDate.OvalPrintingReportDetails);

                }
                entity.IsRemoved = false;
                entity.CreateDate = DateTime.Now;
                entity.OvalPrintingReportDetails.ToList().ForEach(b => { b.IsRemoved = false; b.CreateDate = DateTime.Now;   });
                dbCon.Add(entity);

                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
                rResult.statusCode = entity.ID;
                rResult.statusMsg = entity.ReportDate.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}
