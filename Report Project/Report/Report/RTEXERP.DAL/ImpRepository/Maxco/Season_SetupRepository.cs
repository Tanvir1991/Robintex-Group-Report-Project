using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
   public class Season_SetupRepository :GenericRepository<Season_Setup>, ISeason_SetupRepository
    {
        private MaxcoDBContext dbCon;

        public Season_SetupRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }
    }
}
