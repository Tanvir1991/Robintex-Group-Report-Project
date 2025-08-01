using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
    public interface IFabricBookingService
    {
        Task<FabricBookingMasterViewModel> GetFabticBookingMasterByBookingID(int FabticBookingID);
        Task<RResult> FabricBookingSave(FabricBookingViewModel fabricBooking,int createdBy, bool? savechange);
        Task<List<FabricBookingViewModel>> GetFabricBookingList(int OrderID = 0, DateTime? DateFrom = null, DateTime? DateTo = null);
        Task<List<SelectListItem>> DDLOrderWiseStyleForFabricBooking(int OrderID, int? FabricBookingID = 0);
        Task<List<FabricBookingVersionViewModel>> FabricBookingVersions(int FabricBookingID, int OrderID);
    }
}
