using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.DBEntities.Maxco.SPModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
    public interface IMaxcoReportService
    {
        Task<OrderSheetReport> OrderSheetReportData(int CurrentVersionID);
        Task<List<OrderSheetVersionSPModel>> GetOrderVersion(string OrderNo);
        Task<OrderSheetFirstAndLastVersionSPModel> GetOSVersionDifferenceInfo(int OrderID, int BuyerID);
    }
}
