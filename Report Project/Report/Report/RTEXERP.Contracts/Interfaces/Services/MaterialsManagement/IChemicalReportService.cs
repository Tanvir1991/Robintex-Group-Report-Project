using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
    public interface IChemicalReportService
    {
        Task<List<ChemicalStockSPModel>> GetChemicalStock(int CompanyID, DateTime DateFrom, DateTime DateTo, string ReportItemType, int WithAllTransaction);
        Task<List<ChemicalStockSPModel>> GetChemicalItemDetail(int CompanyID, int ItemID, int UnitID, DateTime DateFrom, DateTime DateTo, string ReportItemType, int WithAllTransaction);
    }
}
