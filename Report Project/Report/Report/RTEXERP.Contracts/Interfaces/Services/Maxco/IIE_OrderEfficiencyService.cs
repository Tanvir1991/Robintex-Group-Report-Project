using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
  public  interface IIE_OrderEfficiencyService
    {
        Task<RResult> SaveIEOrderEfficiency(IE_OrderEfficiencyViewModel model);
        Task<List<OrderEfficiencyDataModel>> GetOrderEfficientList(DateTime? dateFrom, DateTime? dateTo, int orderID = 0, int styleID = 0, string pantonNo = null);
        Task<IE_OrderEfficiencyViewModel> GetOrderEfficientByID(int ID);
        Task<RResult> Remove(int ID);
        Task<IE_OrderEfficiencyViewModel> GetIEOrderEfficient(int id);

    }
}
