using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
    public interface IMer_StyleMasterService
    {
        Task<List<MerOrderShipmentSPModel>> GetMerOrderShipment(int ZoneID = 0, string StyleNo = null, DateTime? DateFrom = null, DateTime? DateTo = null);
        Task<string> GetNexProgramNumber(string Prefix);
        Task<RResult> OrderMasterSave(Mer_StyleMasterVM model, int createdBy);
    }
}
