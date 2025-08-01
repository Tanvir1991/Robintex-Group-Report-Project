using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class FabricAdjustmentTransferTypeRepository : GenericRepository<FabricAdjustmentTransferType>, IFabricAdjustmentTransferTypeRepository
    {
        private MaxcoDBContext dbCon;
        public FabricAdjustmentTransferTypeRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<SelectListItem>> DDLFabricAdjustmentTransferType()
        {
            var buyerList = await dbCon.FabricAdjustmentTransferType.Select(b => new SelectListItem
            {
                Text = b.FabricAdjustmentTransferTypeName.Trim(),
                Value = b.FabricAdjustmentTransferTypeID.ToString()
            }).ToListAsync();
            return buyerList;
        }
    }
}
