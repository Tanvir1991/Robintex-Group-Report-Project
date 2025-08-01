using RTEXERP.Contracts.BLModels.MaterialsManagement.AttributeInfo;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement
{
   public interface IMM_MRPItemAttributeInstanceRepository:IGenericRepository<MM_MRPItem>
    {
        Task<MRPAttributes> GetForAttributeInstanceXMLToObject(long AttributeinstanceID);
    }
}
