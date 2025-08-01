using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DAL.Extension;
using RTEXERP.DBEntities.MaterialsManagement;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class MM_MRPItemRepository : GenericRepository<MM_MRPItem>, IMM_MRPItemRepository
    {
        private MaterialsManagementDBContext dbCon;

        public MM_MRPItemRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public List<SelectListItem> GetTrimMRPItem()
        {
            List<SelectListItem> rList = new List<SelectListItem>();
            DbParameter[] parm = new DbParameter[0];

            string sql = @"SELECT M.MRPItemCode,M.MName FROM MM_MRPItem M
                           INNER JOIN Maxco.dbo.Trim_Setup T ON M.MRPItemCode = T.MRPItemCode";

            DataTable data = dbCon.DataTableSqlQuery(sql, new DbParameter[0]);
            foreach(DataRow d in data.Rows)
            {
                rList.Add(new SelectListItem
                {
                    Text = d["MName"].ToString(),
                    Value = d["MRPItemCode"].ToString(),
                });

            }
            
            return rList;
        }
    }
}