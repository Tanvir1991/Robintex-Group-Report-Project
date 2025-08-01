using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.CMS;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.CMS
{
    public class Pro_MasterRepository : GenericRepository<Pro_Master>, IPro_MasterRepository
    {
        private CMSDBContext dbCon;
        private readonly IMapper mapper;

        public Pro_MasterRepository(CMSDBContext context, IMapper _mapper)
            : base(context)
        {
            dbCon = context;
            mapper = _mapper;

        }

        public async Task<List<SelectListItem>> DDLProductionOrder(DateTime ProductinDateFrom, DateTime ProductionDateTo, int BuyerID = 0)
        {
            var DDLlist = new List<SelectListItem>();
            await dbCon.LoadStoredProc("ajt.usp_DDLGarmentsProductionOrder")
                      .WithSqlParam("BuyerID", BuyerID)
                      .WithSqlParam("ProductinDateFrom", ProductinDateFrom)
                      .WithSqlParam("ProductionDateTo", ProductionDateTo)
                      .ExecuteStoredProcAsync((handler) =>
                      {
                          DDLlist = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                      });


            return DDLlist;


        }
    }
}
