using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.EMS;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMS;
using RTEXERP.DAL.DataContext;
using RTEXERP.DAL.Extension;
using RTEXERP.DBEntities.EMS;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMS
{
    public class FCR_InvoiceOrderMappingRepository : GenericRepository<FCR_InvoiceOrderMapping>, IFCR_InvoiceOrderMappingRepository
    {
        private EMSDBContext dbCon;
        public FCR_InvoiceOrderMappingRepository(EMSDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<FCR_InvoiceOrderMappingViewModel>> FCR_InvoiceOrderMappingDetail(int InvoiceID)
        {
            List<FCR_InvoiceOrderMappingViewModel> returnList = new List<FCR_InvoiceOrderMappingViewModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.usp_GetFCR_InvoiceOrderMappingDetail")
                      .WithSqlParam("InvoiceID", InvoiceID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    returnList = handler.ReadToList<FCR_InvoiceOrderMappingViewModel>() as List<FCR_InvoiceOrderMappingViewModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnList;
        }

        public async Task<RResult> FCR_InvoiceOrderMappingSave(FCR_InvoiceOrderMapping entity, bool? saveChange = true)
        {
            RResult rResult = new RResult();
            try
            {
                entity.CreatedDate = DateTime.Now;
                dbCon.FCR_InvoiceOrderMapping.Add(entity);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<RResult> FCR_InvoiceOrderMappingSave(List<FCR_InvoiceOrderMapping> entityList, bool? saveChange = true)
        {
            RResult rResult = new RResult();
            try
            {
                entityList.ForEach(x=> { x.CreatedDate = DateTime.Now; });
                dbCon.FCR_InvoiceOrderMapping.AddRange(entityList);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<List<GSPInvoiceDataModel>> InvoiceOrderMappingValidation(string OrderNoXML, int CompanyID,int ExportServiceTypeID)
        {
            List<GSPInvoiceDataModel> returnList = new List<GSPInvoiceDataModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_InvoiceOrderMappingValidation")
                      .WithSqlParam("OrderNoXML", OrderNoXML)
                      .WithSqlParam("ExportServiceTypeID", ExportServiceTypeID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    returnList = handler.ReadToList<GSPInvoiceDataModel>() as List<GSPInvoiceDataModel>;
                });
                returnList.ForEach(x => { x.Status = x.InsertedData > 0 ? "Saved Data" : (x.InvoiceID > 0 && x.OrderID > 0) == true ? "Valid" : "Invalid"; });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnList;
        }

        public async Task<List<FCR_InvoiceOrderMappingViewModel>> ValidateFCR_InvoiceOrderMapping(string OrderNoXML)
        {
            List<FCR_InvoiceOrderMappingViewModel> returnList = new List<FCR_InvoiceOrderMappingViewModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.usp_ValidateFCR_InvoiceOrderMapping")
                      .WithSqlParam("doc", OrderNoXML)
                .ExecuteStoredProcAsync((handler) =>
                {
                    returnList = handler.ReadToList<FCR_InvoiceOrderMappingViewModel>() as List<FCR_InvoiceOrderMappingViewModel>;
                });
                returnList.ForEach(x => { x.Comment = x.ID>0 ?"Saved Data": (x.InvoiceID > 0 && x.OrderID > 0) == true ? "Valid" : "Invalid"; });
                //returnList.ForEach(x => { x.Comment =   (x.InvoiceID > 0 && x.OrderID > 0) == true ? "Valid" : "Invalid"; });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnList;
        }
    }
}
