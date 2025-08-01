using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
  public interface IVoucherTypeRepository : IGenericRepository<VoucherTypeSetup>
    {
        Task<IEnumerable<VoucherTypeSetup>> GetVoucherType();
        Task<VoucherTypeSetup> GetVoucherType(int Id);
        Task<List<SelectListItem>> DDLVoucherTypeList(List<int> Ids);
    }
}
