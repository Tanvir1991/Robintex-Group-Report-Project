using RTEXERP.Contracts.BLModels.AOP.DigitalPrintReportModel;
using RTEXERP.Contracts.BLModels.AOP.ReportModel;
using RTEXERP.Contracts.Interfaces.Repositories.AOP;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.AOP;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.AOP
{

    public class AOPCostingRepository : GenericRepository<User_Setup>, IAOPCostingRepository
    {
        private AOPDBContext dbCon;

        public AOPCostingRepository(AOPDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<AOPCostingReportModel>> Aop_Cost_Summary_Issue(DateTime stdate, DateTime enddate)
        {
            List<AOPCostingReportModel> returnStr = new List<AOPCostingReportModel>();
            try
            {
                await dbCon.LoadStoredProc("Sp_Aop_Cost_Summary_Issue", commandTimeout: 20000)
                .WithSqlParam("stdate", stdate)
                 .WithSqlParam("enddate", enddate)
                .ExecuteStoredProcAsync((handler) =>
                {
                    returnStr = handler.ReadToList<AOPCostingReportModel>() as List<AOPCostingReportModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnStr;
        }

        public async Task<DigitalPrintCostingReportModel> DigitalPrint_Cost_Summary_Issue(DateTime stdate, DateTime enddate)
        {
            DigitalPrintCostingReportModel returnData = new DigitalPrintCostingReportModel();
            try
            {
                await dbCon.LoadStoredProc("Sp_DigitalPrint_Cost_Summary_Issue", commandTimeout: 20000)
                .WithSqlParam("stdate", stdate)
                 .WithSqlParam("enddate", enddate)
                .ExecuteStoredProcAsync((handler) =>
                {
                    returnData.InHouseDigitalPrintCosting = handler.ReadToList<InHouseDigitalPrintCostingReportModel>() as List<InHouseDigitalPrintCostingReportModel>;
                    handler.NextResult();
                    returnData.SubContractDigitalPrintCosting = handler.ReadToList<SubContractDigitalPrintCostingReportModel>() as List<SubContractDigitalPrintCostingReportModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnData;
        }
    }

}