using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
   public class MER_ZoneRepository :GenericRepository<MER_Zone>, IMER_ZoneRepository
    {
        private MaxcoDBContext dbCon;

        public MER_ZoneRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }
    }
}
