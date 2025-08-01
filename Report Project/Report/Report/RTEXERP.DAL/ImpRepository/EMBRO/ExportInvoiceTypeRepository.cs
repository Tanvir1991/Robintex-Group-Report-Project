using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class ExportInvoiceTypeRepository : GenericRepository<ExportInvoiceType>, IExportInvoiceTypeRepository
    {
        private EmbroDBContext dbCon;
        public ExportInvoiceTypeRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLExportInvoiceType()
        {
            var list =await dbCon.ExportInvoiceType
                    .Select(x => new SelectListItem
                    {
                        Text = x.Type,
                        Value = x.ID.ToString()
                    }).ToListAsync();
            return list;
        }
    }
}
