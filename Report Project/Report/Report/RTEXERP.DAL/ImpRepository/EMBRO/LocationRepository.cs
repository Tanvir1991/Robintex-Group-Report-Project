using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class LocationRepository : GenericRepository<DBEntities.Embro.Location>, ILocationRepository
    {
        private EmbroDBContext dbCon;

        public LocationRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<IEnumerable<DBEntities.Embro.Location>> GetLocation()
        {
            return await dbCon.Location.ToListAsync();
        }

        public async Task<DBEntities.Embro.Location> GetLocation(int LocationId)
        {
            return await dbCon.Location.FirstOrDefaultAsync(b => (int)b.SrNum == LocationId);
        }
    }
}
