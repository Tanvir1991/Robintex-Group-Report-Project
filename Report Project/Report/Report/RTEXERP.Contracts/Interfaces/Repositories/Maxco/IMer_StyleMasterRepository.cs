using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
  public   interface IMer_StyleMasterRepository :IGenericRepository<Mer_StyleMaster>
    {
        Task<string> GetNexProgramNumber(string Prefix);
        Task<RResult> OrderMasterSave(Mer_StyleMaster model);
        Task<List<MerOrderShipmentSPModel>> GetMerOrderShipment(int ZoneID=0,string StyleNo=null, DateTime? DateFrom=null, DateTime? DateTo=null);
    }
}
