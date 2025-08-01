using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
  public  class CMBL_StockTransactionService: ICMBL_StockTransactionService
    {
        private readonly ICMBL_StockTransactionRepository cMBL_StockTransactionRepository;

        public CMBL_StockTransactionService(ICMBL_StockTransactionRepository _cMBL_StockTransactionRepository)
        {
            cMBL_StockTransactionRepository = _cMBL_StockTransactionRepository;
        }

        public async Task<UnitDetailsViewModel> GetDocumentTypeWiseRate(int itemid)
        {
            return await cMBL_StockTransactionRepository.GetDocumentTypeWiseRate(itemid); 
        }
    }
}
