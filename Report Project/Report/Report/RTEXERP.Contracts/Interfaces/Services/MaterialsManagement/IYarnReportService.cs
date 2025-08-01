using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
    public interface IYarnReportService
    {
        Task<List<YarnStockSPModel>> GetYarnStock(DateTime DateFrom, DateTime DateTo, int WithAllTransaction);
    }
}
