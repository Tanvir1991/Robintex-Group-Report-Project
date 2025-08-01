using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class ChemicalReportService : IChemicalReportService
    {
        private readonly IChemicalReportRepository chemicalReportRepository;
        public ChemicalReportService(IChemicalReportRepository chemicalReportRepository)
        {
            this.chemicalReportRepository = chemicalReportRepository;
        }

        public async Task<List<ChemicalStockSPModel>> GetChemicalItemDetail(int CompanyID, int ItemID, int UnitID, DateTime DateFrom, DateTime DateTo, string ReportItemType, int WithAllTransaction)
        {
            return await chemicalReportRepository.GetChemicalItemDetail(CompanyID, ItemID, UnitID, DateFrom, DateTo, ReportItemType, WithAllTransaction);
        }

        public async Task<List<ChemicalStockSPModel>> GetChemicalStock(int CompanyID, DateTime DateFrom, DateTime DateTo, string ReportItemType, int WithAllTransaction)
        {
            return await chemicalReportRepository.GetChemicalStock(CompanyID, DateFrom, DateTo, ReportItemType, WithAllTransaction);
        }
    }
}
