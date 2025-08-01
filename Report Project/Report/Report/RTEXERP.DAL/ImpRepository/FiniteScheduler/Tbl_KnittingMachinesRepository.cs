using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class Tbl_KnittingMachinesRepository : GenericRepository<Tbl_KnittingMachines>, ITbl_KnittingMachinesRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public Tbl_KnittingMachinesRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLMachine(int CompanyID = 0)
        {
            try
            {
                var data = dbCon.Tbl_KnittingMachines.Where(b => b.DIA > 0);
                if (CompanyID > 0)
                {
                    data = data.Where(b => b.CompanyID == CompanyID);
                }
                data = data.OrderBy(b => b.CompanyID); 
                var rdata = data.Select(b => new SelectListItem
                {
                    Text = $"{b.MachineNo} - {b.BRAND}",
                    Value = b.MachineNo.ToString(),
                    Group = new SelectListGroup() { Name = b.CompanyID == 183 ? "Robintex" : "Comptex" }
                });

                var _rdata = await rdata.ToListAsync();

                return _rdata;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<SelectListItem>> DDLMachine(int CompanyID = 0, bool IsIncludeSubcontact = true)
        {
           
            try
            {
                var data = dbCon.Tbl_KnittingMachines.Where(b => b.DIA > 0);
                if (CompanyID > 0)
                {
                    data = data.Where(b => b.CompanyID == CompanyID);
                }
                if (IsIncludeSubcontact)
                {
                    data = data.Where(b => b.MachineNo >0);
                }
                data = data.OrderBy(b => b.CompanyID);

                var rdata = data.Select(b => new SelectListItem
                {
                    Text = $"{b.MachineNo} - {b.BRAND}",
                    Value = b.MachineNo.ToString(),
                    Group = new SelectListGroup() { Name = b.CompanyID == 183 ? "Robintex" : "Comptex" }
                });
                

                var _rdata = await rdata.ToListAsync();

                return _rdata;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Tbl_KnittingMachines> GetMachineInfo(int MachineNo)
        {
            var query = await dbCon.Tbl_KnittingMachines.Where(b => b.MachineNo == MachineNo).FirstOrDefaultAsync();
            return query;
            

        }
    }
}
