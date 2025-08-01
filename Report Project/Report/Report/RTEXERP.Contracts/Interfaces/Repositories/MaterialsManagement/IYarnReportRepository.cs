using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement
{
    public interface IYarnReportRepository:IGenericRepository<YarnStockSPModel>
    {
        Task<List<YarnStockSPModel>> GetYarnStock(DateTime DateFrom,DateTime DateTo,int WithAllTransaction);
    }
}
