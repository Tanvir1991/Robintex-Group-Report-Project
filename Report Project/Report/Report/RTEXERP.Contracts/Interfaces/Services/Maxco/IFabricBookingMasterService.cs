using RTEXERP.Contracts.BLModels.Maxco.SPModel.FabricBooking;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
    public interface IFabricBookingMasterService
    {
        Task<List<FRSFabricForBooking>> GETFRSFabricForBooking(List<int> StyleIDList);
        Task<FabricBookingMasterViewModel> GETFRSFabricFullDataForBooking(List<int> StyleIDList);
    }
}
