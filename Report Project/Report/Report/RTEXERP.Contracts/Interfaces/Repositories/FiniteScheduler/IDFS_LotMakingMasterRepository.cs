using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
  public  interface IDFS_LotMakingMasterRepository :IGenericRepository<DFS_LotMakingMaster>
    {
        Task<List<SelectListItem>> DDLLot(DateTime CreationDateFrom ,DateTime CreationDateTo,string Predict=null, long OrderID=0);

        Task<List<SelectListItem>> DDLLotRequisition(DateTime LotDateFrom, DateTime LotDateTo, string Predict = null, long OrderID = 0);
        Task<List<OrderWiseLotRequisitionVM>> GetOrderWiseLotRequisitionList(int OrderID);
    }
}
