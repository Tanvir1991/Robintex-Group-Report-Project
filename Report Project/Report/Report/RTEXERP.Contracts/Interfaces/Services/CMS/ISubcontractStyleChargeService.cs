using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.CMS
{
    public interface ISubcontractStyleChargeService
    {
        /// <summary>
        /// true = Duplicate
        /// false = Unique
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        Task<bool> IsDuplicateOrder(long OrderID);
        Task<RResult> AddSubcontract(SubcontractStyleChargeVM model);
        Task<RResult> UpdateSubcontract(SubcontractStyleChargeVM model);
        Task<RResult> RemoveSubcontract(SubcontractStyleChargeVM model);
        Task<List<SubcontractStyleChargeListVM>> GetSubContractCharge(DateTime DateFrom, DateTime DateTo);
    }
}
