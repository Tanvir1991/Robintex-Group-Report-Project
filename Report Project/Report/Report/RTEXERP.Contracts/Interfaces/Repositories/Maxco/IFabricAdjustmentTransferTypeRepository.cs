using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
    public interface IFabricAdjustmentTransferTypeRepository:IGenericRepository<FabricAdjustmentTransferType>
    {
        Task<List<SelectListItem>> DDLFabricAdjustmentTransferType();
    }
}
