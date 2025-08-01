using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts
{
   public interface IExtendedGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

    }
}
