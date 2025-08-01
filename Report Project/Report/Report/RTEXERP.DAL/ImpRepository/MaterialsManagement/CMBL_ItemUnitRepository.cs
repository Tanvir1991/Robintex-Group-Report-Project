using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class CMBL_ItemUnitRepository:GenericRepository<CMBL_ItemUnit>, ICMBL_ItemUnitRepository
    {
        private MaterialsManagementDBContext dbCon;
        public CMBL_ItemUnitRepository(MaterialsManagementDBContext context)
              : base(context)
        {
            dbCon = context;
        }
    }
}
