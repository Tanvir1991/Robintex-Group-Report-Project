using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMBRO
{
  public  interface IVoucherTypeService
    {
        Task<IEnumerable<VoucherTypeSetup>> GetVoucherType();
        Task<VoucherTypeSetup> GetVoucherType(int Id);
    }
}
