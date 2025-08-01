using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
   public interface IPantoneRepository :IGenericRepository<Pantone>
    {
        Task<List<BasicModel>> GetPantoneColor(string ColorName, int limit = 15);
    }
}
