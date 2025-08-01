using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
    public interface IPantoneService
    {
        Task<List<BasicModel>> GetPantoneColor(string ColorName, int limit = 15);

    }
}
