using RTEXERP.Contracts.BLModels.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
   public interface ICMBL_StockTransactionService
    {
        Task<UnitDetailsViewModel> GetDocumentTypeWiseRate(int itemid);
    }
}
