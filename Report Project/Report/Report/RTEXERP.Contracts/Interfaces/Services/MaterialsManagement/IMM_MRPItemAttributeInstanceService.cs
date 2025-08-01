using RTEXERP.Contracts.BLModels.MaterialsManagement.AttributeInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
   public interface IMM_MRPItemAttributeInstanceService
    {
        Task<MRPAttributes> GetForAttributeInstanceXMLToObject(long AttributeinstanceID);
    }
}
