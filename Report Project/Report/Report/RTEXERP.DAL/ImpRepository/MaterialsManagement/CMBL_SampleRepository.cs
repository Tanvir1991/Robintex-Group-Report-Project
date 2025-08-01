using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class CMBL_SampleRepository : GenericRepository<CMBL_Sample>, ICMBL_SampleRepository
    {
        private MaterialsManagementDBContext dbCon;
        private IMapper mapper;
        public CMBL_SampleRepository(MaterialsManagementDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
        public async Task<RResult> CMBL_SampleSave(CMBL_SampleViewModel model, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var Sample = mapper.Map<CMBL_SampleViewModel, CMBL_Sample>(model);                
                Sample.CreationDate = DateTime.Now;
                Sample.UserID = createdBy;
                Sample.ApprovedBy = 1;
                Sample.LocationSelStatus = 1;
                Sample.DateSelStatus = 1;
                Sample.PriceSelStatus = 1;
                Sample.SampleStatus = 1;


                dbCon.CMBL_Sample.Add(Sample);
                await dbCon.SaveChangesAsync();

                var newSample = Sample;
                newSample.SampleNo = Sample.SampleID;                
                dbCon.Entry(Sample).CurrentValues.SetValues(newSample);
                await dbCon.SaveChangesAsync();

                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public Task<List<SelectListItem>> DDLSampleNo()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CMBL_SampleItemViewModel>> GetRequisitionWiseItemList(long CompanyId, long RequisitionNo)
        {
            var itemList = new List<CMBL_SampleItemViewModel>();
            try
            {
                await dbCon.LoadStoredProc("CMBL_GetRequisitionWiseItems")
                             .WithSqlParam("CompanyId", CompanyId)
                             .WithSqlParam("RequisitionNo", RequisitionNo)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<CMBL_SampleItemViewModel>() as List<CMBL_SampleItemViewModel>;
                             });

               

                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<CMBL_SampleItemViewModel>> GetRequisitionWiseItemListForGateReceiving(long sampleNo)
        {
            var itemList = new List<CMBL_SampleItemViewModel>();
            try
            {
                await dbCon.LoadStoredProc("CMBL_GetRequisitionWiseItemsForGateReceiving")
                             .WithSqlParam("SampleNo", sampleNo)                             
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<CMBL_SampleItemViewModel>() as List<CMBL_SampleItemViewModel>;
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
