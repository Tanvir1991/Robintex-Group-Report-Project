using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class CMBL_ItemRepository:GenericRepository<CMBL_Item>, ICMBL_ItemRepository
    {
        private MaterialsManagementDBContext dbCon;
        public CMBL_ItemRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;
        }
    }
}
