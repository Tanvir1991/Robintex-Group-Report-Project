using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
  public  interface IKRS_MASTERService
    {
        Task<List<KRSOrderFabricSPModel>> GetKRSOrderFabricList(int kRSID = 0, int orderID = 0);
    }
}
