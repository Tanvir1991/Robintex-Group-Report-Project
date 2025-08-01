using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMBRO
{
   public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocation();
        Task<Location> GetLocation(int LocationId);
    }
}
