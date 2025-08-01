using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
    public interface IFabricBookingRepository : IGenericRepository<FabricBooking>
    {
        Task<RResult> FabricBookingSave(FabricBooking fabricBooking, bool? savechange);
        Task<RResult> FabricBookingUpdate(int fabricBookingID, int updatedBy, bool? savechange);
        Task<RResult> UpdateCurrentVersionNo(int fabricBookingID, int updatedBy, bool? savechange);
        Task<List<FabricBookingViewModel>> GetFabricBookingList(int OrderID = 0, DateTime? DateFrom = null, DateTime? DateTo = null);
        Task<List<SelectListItem>> DDLOrderWiseStyleForFabricBooking(int OrderID, int? FabricBookingID=0);
        Task<List<FabricBookingVersionViewModel>> FabricBookingVersions(int FabricBookingID, int OrderID);


    }
}
