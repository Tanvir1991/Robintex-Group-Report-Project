using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class CMBL_DocumentType_SetupRepository:GenericRepository<CMBL_DocumentType_Setup>, ICMBL_DocumentType_SetupRepository
    {
        private MaterialsManagementDBContext dbCon;
        public CMBL_DocumentType_SetupRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;
        }
    }
}
