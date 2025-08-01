using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.Interfaces.Repositories.Hrm;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Hrm;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Hrm
{
    public class Tbl_EmpRepository : GenericRepository<Tbl_Emp>, ITbl_EmpRepository
    {

        private HRTESTContext dbCon;
        public Tbl_EmpRepository(HRTESTContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<Tbl_EmpViewModel>> Get_EmpsForShiftReport(string EMPCode)
        {
            try
            {
                var ConditionalempList = this.ConditionalEMPCOde(EMPCode);
                var emplist = await dbCon.Tbl_Emp.Where(b => ConditionalempList.Contains(b.EmpCd))
                    .Select(b => new Tbl_EmpViewModel
                    {
                        EmpName = b.EmpName,
                        EmpBname = ((b.EmpBname == null || b.EmpBname == "") ? b.EmpName : b.EmpBname),
                        EmpCd = b.EmpCd,
                        EMPCodeBangla = EnglishNumberToBangla(b.EmpCd)


                    }).ToListAsync();
                return emplist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<List<EmployeeElectionInfoViewModel>> GetEmployeeElectionInfo(string employeeCodeList)
        {
            List<EmployeeElectionInfoViewModel> modelList = new List<EmployeeElectionInfoViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_EmployeeElectionInfo")
                  .WithSqlParam("List", employeeCodeList)
                            .ExecuteStoredProcAsync((handler) =>
                            {
                                modelList = handler.ReadToList<EmployeeElectionInfoViewModel>() as List<EmployeeElectionInfoViewModel>;
                            });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return modelList;
        }

        #region Private Function

        private List<string> ConditionalEMPCOde(string EMPCode)
        {
            List<string> rList = new List<string>();
            if (EMPCode.Contains(","))
            {
                rList = EMPCode.Split(',').Select(b => b.Trim()).ToList();
            }
            else
            {
                rList.Add(EMPCode.Trim());
            }
            return rList;
        }

        public string EnglishNumberToBangla(string Code)
        {
            return Code.Replace("1", "১")
                        .Replace("2", "২")
                        .Replace("3", "৩")
                        .Replace("4", "৪")
                        .Replace("5", "৫")
                        .Replace("6", "৬")
                        .Replace("7", "৭")
                        .Replace("8", "৮")
                        .Replace("9", "৯")
                        .Replace("0", "0");
        }


        #endregion
    }
}
