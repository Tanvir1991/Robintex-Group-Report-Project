using AutoMapper;
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
    public class tbl_Currency_SetupRepository : GenericRepository<tbl_Currency_Setup>, Itbl_Currency_SetupRepository
    {
        private EmbroDBContext dbCon;
        private IMapper mapper;
        public tbl_Currency_SetupRepository(EmbroDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }        

        public async Task<List<SelectListItem>> DDLCurrencyList()
        {
            try
            {
                var list = await dbCon.TblCurrencySetup
                           .Select(row => new SelectListItem
                           {
                               Text = row.CurrencyName,
                               Value = row.Id.ToString()
                           }).ToListAsync();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
