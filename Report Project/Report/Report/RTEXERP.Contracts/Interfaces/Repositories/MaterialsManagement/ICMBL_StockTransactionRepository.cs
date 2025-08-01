using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement
{
  public  interface ICMBL_StockTransactionRepository: IGenericRepository<CMBL_StockTransaction>
    {
        Task<UnitDetailsViewModel> GetDocumentTypeWiseRate( int itemid);
    }
}
