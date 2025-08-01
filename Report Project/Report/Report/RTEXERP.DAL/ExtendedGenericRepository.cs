using RTEXERP.Contracts;
using RTEXERP.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL
{
      public class ExtendedGenericRepository<TEntity> : GenericRepository<TEntity>, IExtendedGenericRepository<TEntity> where TEntity : class
    {
        //Just need to pass db context to GenericRepository. 
        public ExtendedGenericRepository(ReportDBContext context)
            : base(context)
        {
        }

    }
}
