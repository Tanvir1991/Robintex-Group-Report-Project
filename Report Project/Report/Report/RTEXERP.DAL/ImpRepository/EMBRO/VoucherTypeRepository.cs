using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class VoucherTypeRepository : GenericRepository<VoucherTypeSetup>, IVoucherTypeRepository
    {
        private EmbroDBContext dbCon;

        public VoucherTypeRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<SelectListItem>> DDLVoucherTypeList(List<int> Ids)
        {
            var voucherList= await dbCon.VoucherTypeSetup.Where(x => Ids.Contains(x.Id))
                .Select(r => new SelectListItem
                {
                    Text = $"{ r.VoucherType}({r.Initials})",
                    Value = r.Id.ToString()
                }).ToListAsync();
            return voucherList;
        }

        public async Task<IEnumerable<VoucherTypeSetup>> GetVoucherType()
        {
            return await dbCon.VoucherTypeSetup.ToListAsync();
        }

        public async Task<VoucherTypeSetup> GetVoucherType(int Id)
        {
            return await dbCon.VoucherTypeSetup.FirstOrDefaultAsync(b => b.Id == Id);
        }
    }
}
