using RTEXERP.Contracts.BLModels.Maxco.SPModel.FabricBooking;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
    public interface IFabricBookingMasterRepository : IGenericRepository<FabricBookingMaster>
    {
        Task<List<FRSFabricForBooking>> GETFRSFabricForBooking(string StyleXML);
        Task<RResult> FabricBookingMasterSave(List<FabricBookingMaster> entity, bool? savechange);
    }
}
