using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
   public interface IIE_OrderEfficiencyRepository:IGenericRepository<IE_OrderEfficiency>
    {
        Task<RResult> SaveIEOrderEfficiency(IE_OrderEfficiency model);
        Task<List<OrderEfficiencyDataModel>> GetOrderEfficientList(DateTime? dateFrom, DateTime? dateTo, int orderID = 0, int styleID = 0, string pantonNo = null);
        Task<IE_OrderEfficiency> GetOrderEfficientByID(int ID);
        Task<RResult> Remove(int ID);
        Task<IE_OrderEfficiencyViewModel> GetIEOrderEfficient(int id);
    }
}
