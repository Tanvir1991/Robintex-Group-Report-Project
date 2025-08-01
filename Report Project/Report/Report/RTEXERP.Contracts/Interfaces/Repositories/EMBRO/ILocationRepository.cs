using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
   public interface ILocationRepository : IGenericRepository<Location>
    {
        Task<IEnumerable<Location>> GetLocation();
        Task<Location> GetLocation(int LocationId);

    }
}
