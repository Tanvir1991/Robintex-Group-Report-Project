using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Materials;
using RTEXERP.Contracts.Interfaces.Repositories.Materials;
using RTEXERP.DAL.DataContext;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Materials
{
    public class LotNoRepository : GenericRepository<YarnLotNo>, ILotNoRepository
    {
        private MaterialsManagementDBContext dbCon;
        private IMapper mapper;
        public LotNoRepository(MaterialsManagementDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }

        public async Task<List<SelectListItem>> DDLLotList(DateTime? DateFrom,DateTime ? DateTo)
        {
            List<YarnLotNo> model = new List<YarnLotNo>();

            try
            {
                await dbCon.LoadStoredProc("usp_GetBlanceLotNo")
             .WithSqlParam("DateFrom", DateFrom)
             .WithSqlParam("DateTo", DateTo)
             .ExecuteStoredProcAsync((handler) =>
             {
                 model = handler.ReadToList<YarnLotNo>() as List<YarnLotNo>;
             });

                var ddlList = model.Select(b=> new SelectListItem()
                {
                    Text = b.LotNo + " ("+b.BlanceQty.ToString()+")",
                    Value = b.LotNo
                });

                return ddlList.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //return model.FirstOrDefault();
         
        }
    }
}
