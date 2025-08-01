using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.ImpRepository.CMS
{
   public class SubcontractStyleChargeRepository:GenericRepository<SubcontractStyleCharge>, ISubcontractStyleChargeRepository
    {
        private CMSDBContext dbCon;
        public SubcontractStyleChargeRepository(CMSDBContext context)
            : base(context)
        {
            dbCon = context;
        }
      
    }
}
