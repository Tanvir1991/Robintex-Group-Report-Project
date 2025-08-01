using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class CMBL_ItemAttributeSetRepository:GenericRepository<CMBL_ItemAttributeSet>, ICMBL_ItemAttributeSetRepository
    {
        private MaterialsManagementDBContext dbCon;
        public CMBL_ItemAttributeSetRepository(MaterialsManagementDBContext context)
              : base(context)
        {
            dbCon = context;
        }
    }
}
