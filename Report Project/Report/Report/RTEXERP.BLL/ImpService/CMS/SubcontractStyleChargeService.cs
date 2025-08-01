using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.Contracts.Interfaces.Services.CMS;
using RTEXERP.DBEntities.CMS;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.BLModels.CMS;
using System.Collections.Generic;

namespace RTEXERP.BLL.ImpService.CMS
{
    public class SubcontractStyleChargeService : ISubcontractStyleChargeService
    {
        private readonly ISubcontractStyleChargeRepository _subcontractStyleChargeRepository;
        public SubcontractStyleChargeService(ISubcontractStyleChargeRepository subcontractStyleChargeRepository)
        {
            _subcontractStyleChargeRepository = subcontractStyleChargeRepository;
        }
        public async Task<RResult> AddSubcontract(SubcontractStyleChargeVM model)
        {
            RResult oResult = new RResult();
            try
            {
                SubcontractStyleCharge entity = new SubcontractStyleCharge();
                var hasDuplicateOrder = await this.IsDuplicateOrder(model.OrderID);
                if (hasDuplicateOrder)
                {
                    oResult.result = 0;
                    oResult.message = $"\"{model.OrderNo}\" is already inserted.";
                    return oResult;
                }
                entity.OrderID = model.OrderID;
                entity.OrderNo = model.OrderNo;
                entity.OrderRate = model.OrderRate;

                entity.CreatedDate = DateTime.Now;
                entity.IsRemoved = false;
                entity.IsActive = true;
                 await _subcontractStyleChargeRepository.InsertAsync(entity, true);
                if (entity.ID > 0)
                {
                    oResult.result = 1;
                    oResult.message = "Successfully Saved.";
                }
                else
                {
                    oResult.result = 0;
                    oResult.message = "Problem.";
                }
            }catch(Exception e)
            {
                oResult.result = 0;

            }
            return oResult;

        }

        public async Task<List<SubcontractStyleChargeListVM>> GetSubContractCharge(DateTime DateFrom, DateTime DateTo)
        {
            var filterData = await _subcontractStyleChargeRepository.FindAllAsync(b => b.IsRemoved == false
                                                 && b.IsActive == true
                                                 && b.CreatedDate.HasValue == true
                                                 && b.CreatedDate.Value.Date >= DateFrom.Date
                                                 && b.CreatedDate.Value.Date <= DateTo.Date);

            var rtnData = filterData.Select(b => new SubcontractStyleChargeListVM()
            {
               ID = b.ID,
               OrderID = b.OrderID,
               OrderNo = b.OrderNo,
               OrderRate = b.OrderRate,
              CreateDate = b.CreatedDate
            }).OrderByDescending(b=>b.CreateDate).ToList();
            return rtnData;                      
      
        }

        /// <summary>
        /// true = Duplicate
        /// false = Unique
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public async Task<bool> IsDuplicateOrder(long OrderID)
        {
            var hasOrder = await _subcontractStyleChargeRepository.FindAllAsync(b => b.IsActive == true
                                                                           && b.IsRemoved == false
                                                                           && b.OrderID == OrderID);
            if (hasOrder != null && hasOrder.Count>0)
            {
                return true;
            }
            return false;
        }

        public async Task<RResult> RemoveSubcontract(SubcontractStyleChargeVM model)
        {
            RResult oResult = new RResult();
            var hasDbData = await _subcontractStyleChargeRepository.FindAsync(b => b.IsRemoved == false && b.IsActive == true && b.OrderID == model.OrderID);
            if (hasDbData==null)
            {
                oResult.result = 0;
                oResult.message = "Problem";
                return oResult;

            }
            hasDbData.IsRemoved = true;
            hasDbData.UpdateDate = DateTime.Now;
            var UpdateDB = await _subcontractStyleChargeRepository.UpdateAsync(hasDbData,model.ID,true);
            oResult.result = 1;
            oResult.message = "Remove Successfully.";
            return oResult;

        }

        public async Task<RResult> UpdateSubcontract(SubcontractStyleChargeVM model)
        {
            RResult oResult = new RResult();
            var hasDbData = await _subcontractStyleChargeRepository.FindAsync(b => b.IsRemoved == false && b.IsActive == true && b.OrderID != model.OrderID);
            if (hasDbData == null)
            {
                oResult.result = 0;
                oResult.message = "Problem";
                return oResult;

            }
            hasDbData.OrderID = model.OrderID;
            hasDbData.OrderNo = model.OrderNo;
            hasDbData.OrderRate = model.OrderRate;
             hasDbData.UpdateDate = DateTime.Now;
            var UpdateDB = await _subcontractStyleChargeRepository.UpdateAsync(hasDbData, model.ID, true);
            oResult.result = 1;
            oResult.message = "Remove Successfully.";
            return oResult;
        }
    }
}
