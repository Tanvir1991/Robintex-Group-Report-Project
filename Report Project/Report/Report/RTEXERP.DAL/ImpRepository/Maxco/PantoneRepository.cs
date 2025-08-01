using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class PantoneRepository : GenericRepository<Pantone>, IPantoneRepository
    {
        private MaxcoDBContext dbCon;

        public PantoneRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<BasicModel>> GetPantoneColor(string ColorName, int limit = 15)
        {
            var data = dbCon.Pantone.Where(b => b.Description.Length > 0);

            if (ColorName.Length > 0)
            {
                data = data.Where(b => b.Description.Contains(ColorName));
            }
            data = data.OrderBy(b => b.Description);

            if (limit > 0)
            {
                data = data.Take(limit);
            }

            var _data = await data.Select(b => new BasicModel
            {
                Description = b.Description.Trim()

            }).Distinct().ToListAsync();
            return _data;

        }
    }
}
