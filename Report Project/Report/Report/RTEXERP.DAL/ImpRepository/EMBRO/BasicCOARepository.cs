using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
 
using RTEXERP.Contracts.BLModels.EMBRO;
 
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Embro;
 
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
 
using System.Threading.Tasks;
using System.Web;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class BasicCOARepository : GenericRepository<BasicCoa>, IBasicCOARepository
    {

        private EmbroDBContext dbCon;
       
        public BasicCOARepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;
            
        }

        public async Task<BasicCoa> AccInfo(int Id)
        {
            try
            {
                var info =await dbCon.BasicCoa.Where(b => b.Id == Id).FirstOrDefaultAsync();
                return info;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<SelectListItem>> DDLAccCategory(int Selected)
        {
            List<int> category = new List<int> { 4, 5, 6, 7, 8, 14 };
            var catList = await dbCon.Levels.Where(b => category.Contains(b.Id))
               .Select(s => new SelectListItem
               {
                   Text = s.Description,
                   Value = s.Id.ToString(),
                   Selected = s.Id==Selected?true:false
               }).ToListAsync();
           return catList;
        }

        public async Task<List<SelectListItem>> DDLChartOfAccounts(int? parentId, int levelId)
        {
            try
            {
                var list = from c in dbCon.BasicCoa
                           where c.LevelId == levelId
                           select new BasicCoa { Id = c.Id, AccountCode = c.AccountCode, Description = c.Description, ParentId = c.ParentId, LevelId = c.LevelId };

                if (parentId != null && parentId > 0)
                {
                    list = list.Where(b => b.ParentId == parentId);
                }
                if (levelId == 1)
                {
                    list = list.Where(b => b.Id != 3684);
                }
                var nlist = await list.ToListAsync();

                var rList = nlist.Select(row => new SelectListItem
                {
                    Text = row.Description,
                    Value = row.Id.ToString()
                }).ToList();

                return rList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
       public async Task<IEnumerable<SelectListItem>> DDLCategoryChartOfAccounts(int CompanyID, int? CategoryID = 0)
        {
            try
            {
                List<SelectListItem> ddlList = new List<SelectListItem>();
                var data = from coa in dbCon.BasicCoa
                           join sub in dbCon.BasicCoa on (int?)coa.Id equals sub.ParentId
                           join brd in dbCon.BasicCoa on (int?)sub.Id equals brd.ParentId
                           join nrr in dbCon.BasicCoa on (int?)brd.Id equals nrr.ParentId
                           join idd in dbCon.BasicCoa on (int?)nrr.Id equals idd.ParentId
                           join itm in dbCon.BasicCoa on (int?)idd.Id equals itm.ParentId
                           where coa.ParentId == CompanyID
                            && (CategoryID == 0 || (int)coa.Id == CategoryID)
                           select new  
                           {
                               Ledger = HttpUtility.HtmlDecode($"{itm.Description} => {nrr.Description} =>{brd.Description} =>{sub.Description} =>{coa.Description} "),
                               LedgerID= itm.Id.ToString(),
                               Identitfication = idd.Description,
                               IdentitficationID= idd.Id.ToString()
                           };
                var AccList = await data.ToListAsync();
                var _listGroup = AccList.Select(b => new { Name = b.Identitfication, IdentitficationID = b.IdentitficationID }).Distinct().OrderBy(b=>b.Name).ToList();
                foreach(var identity in _listGroup)
                {
                    var _AccList = AccList.Where(b => b.IdentitficationID==identity.IdentitficationID).ToList();
                    //Create the Group.
                    SelectListGroup group = new SelectListGroup() { Name = identity.Name };
                    foreach(var ledger in _AccList)
                    {
                        ddlList.Add(new SelectListItem { Value = ledger.LedgerID, Text = ledger.Ledger, Group = group });
                    }
                }
                ddlList.OrderBy(b => b.Group.Name).ToList();
                return ddlList;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<List<SelectListItem>> DDLChartOfAccountsCompanyWiseSupplier(int companyId)
        {
            var itemList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("usp_GetCompanyWiseSupplierDDL")
                             .WithSqlParam("CompanyId", companyId)
                             
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                             });



                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<BasicCOAViewModel>> ChartOfAccountsSupplierGroup(int companyId, int? CategoryID = 0)
        {
            var data = from category in dbCon.BasicCoa
                       join subCategory in dbCon.BasicCoa on (int?)category.Id equals subCategory.ParentId
                       join BroadGroup in dbCon.BasicCoa on (int?)subCategory.Id equals BroadGroup.ParentId
                       join NarrowGroup in dbCon.BasicCoa on (int?)BroadGroup.Id equals NarrowGroup.ParentId
                       join Identification in dbCon.BasicCoa on (int?)NarrowGroup.Id equals Identification.ParentId
                       join Item in dbCon.BasicCoa on (int?)Identification.Id equals Item.ParentId
                       join suplier in dbCon.SupplierSetup on Item.Id equals suplier.Id
                       where  category.ParentId == companyId
                          select new BasicCOAViewModel
                       {
                           Id = Item.Id,
                           AccName = Item.Description,
                           AccountCode = Item.AccountCode,
                           AllParentAccName = String.Format("{0} <= {1} <= {2} <= {3} <= {4}", Identification.Description, NarrowGroup.Description, BroadGroup.Description, subCategory.Description, category.Description),
                           ImmediateParentAccName = Identification.Description,
                           ParentId = Item.ParentId,
                           CategoryId = (int)category.Id,
                           CompanyId = (int)category.ParentId
                       };
            //if (companyId > 0)
            //{
            //    data = data.Where(b => b.CompanyId == companyId);
            //}
            if (CategoryID > 0)
            {
                data = data.Where(b => b.CategoryId == CategoryID);
            }
            return await data.ToListAsync();

        }

        public async Task<List<BasicCOAViewModel>> ChartOfAccountsGroup(int companyId, int? CategoryID = 0)
        {
            var data = from category in dbCon.BasicCoa
                       join subCategory in dbCon.BasicCoa on (int?)category.Id equals subCategory.ParentId
                       join BroadGroup in dbCon.BasicCoa on (int?)subCategory.Id equals BroadGroup.ParentId
                       join NarrowGroup in dbCon.BasicCoa on (int?)BroadGroup.Id equals NarrowGroup.ParentId
                       join Identification in dbCon.BasicCoa on (int?)NarrowGroup.Id equals Identification.ParentId
                       join Item in dbCon.BasicCoa on (int?)Identification.Id equals Item.ParentId
                       where  category.ParentId == companyId
                       select new BasicCOAViewModel
                       {
                           Id = Item.Id,
                           AccName = Item.Description,
                           AccountCode = Item.AccountCode,
                           AllParentAccName = String.Format("{0} <= {1} <= {2} <= {3} <= {4}", Identification.Description, NarrowGroup.Description, BroadGroup.Description, subCategory.Description, category.Description),
                           ImmediateParentAccName = Identification.Description,
                           ParentId = Item.ParentId,
                           CategoryId = (int)category.Id,
                           CompanyId = (int) category.ParentId
                       };
            //if (companyId > 0)
            //{
            //    data = data.Where(b => b.CompanyId == companyId);
            //}
            if (CategoryID > 0)
            {
                data = data.Where(b => b.CategoryId == CategoryID);
            }
            return await data.ToListAsync();
        }
        public async Task<List<BasicCOAViewModel>> ChartOfAccounts(int? parentId, int levelId)
        {
            try
            {
                var list = from c in dbCon.BasicCoa
                           join l in dbCon.Levels on c.LevelId equals l.Id
                           where c.LevelId == levelId
                           select new BasicCOAViewModel {
                               Id = c.Id,
                               AccountCode = c.AccountCode, 
                               AccName = c.Description, 
                               ParentId = c.ParentId,
                               LevelId = c.LevelId ,
                               LevelName = l.Description
                           };
                if (parentId != null && parentId > 0)
                {
                    list = list.Where(b => b.ParentId == parentId);
                }
                if (levelId == 1)
                {
                    list = list.Where(b => b.Id != 3684);
                }
                var nlist = await list.ToListAsync();
                return nlist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<BasicCOAViewModel>> GetsSupplierListAutocomplete(string itemName, int companyId)
        {

            List<BasicCOAViewModel> supplierList = new List<BasicCOAViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_ItemsLevelAutoComplete")
                .WithSqlParam("itemName", itemName)
                .WithSqlParam("companyId", companyId)
                .WithSqlParam("IsSupplier", 1)
                
                .ExecuteStoredProcAsync((handler) =>
                {
                    supplierList = handler.ReadToList<BasicCOAViewModel>() as List<BasicCOAViewModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return supplierList;

        }
        public async Task<List<BasicCOAViewModel>> GetAutoCompleteChartOfAccounts(string itemName, int companyId)
        {

            List<BasicCOAViewModel> supplierList = new List<BasicCOAViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_ItemsLevelAutoComplete")
                .WithSqlParam("itemName", itemName)
                .WithSqlParam("companyId", companyId)
                .WithSqlParam("IsSupplier", 0)

                .ExecuteStoredProcAsync((handler) =>
                {
                    supplierList = handler.ReadToList<BasicCOAViewModel>() as List<BasicCOAViewModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return supplierList;

        }
        public async Task<List<BasicCOAViewModel>> GetBankAccountAutocomplete(string itemName, int companyId)
        {

            List<BasicCOAViewModel> bankAccountList = new List<BasicCOAViewModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetBankAccountAutocomplete")
                .WithSqlParam("itemName", itemName)
                .WithSqlParam("companyId", companyId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    bankAccountList = handler.ReadToList<BasicCOAViewModel>() as List<BasicCOAViewModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return bankAccountList;

        }



        public async Task<List<SelectListItem>> DDLCompanyVatPayableAccount(int companyId)
        {
            try
            {
                var accList = new List<SelectListItem>();
                var defaultAccId = companyId == 183 ? 26719 : 26721;
                var defaultObj = await dbCon.BasicCoa.Where(x => x.Id == defaultAccId).FirstAsync();
                accList.Add(new SelectListItem { Text = defaultObj.Description + "," + defaultObj.Id.ToString(), Value = defaultObj.Id.ToString() });

                var list = await (from item in dbCon.BasicCoa
                                  join iden in dbCon.BasicCoa on item.ParentId equals (int)iden.Id
                                  join narrow in dbCon.BasicCoa on iden.ParentId equals (int)narrow.Id
                                  join broadgroup in dbCon.BasicCoa on narrow.ParentId equals (int)broadgroup.Id
                                  join sab in dbCon.BasicCoa on broadgroup.ParentId equals (int)sab.Id
                                  join cat in dbCon.BasicCoa on sab.ParentId equals (int)cat.Id
                                  join com in dbCon.BasicCoa on cat.ParentId equals (int)com.Id
                                  where iden.Description == "Taxation Current" && com.Id == companyId
                                  select (new SelectListItem
                                  {
                                      Text = item.Description + "," + item.Id,
                                      Value = item.Id.ToString()
                                  })).ToListAsync();
                accList.AddRange(list);
                return accList;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<SelectListItem>> DDLCompanyAdvanceIncomeTaxAccount(int companyId)
        {
            var accList = new List<SelectListItem>();
            var defaultAccId = companyId == 183 ? 30484 : 30442;
            var defaultObj = await dbCon.BasicCoa.Where(x => x.Id == defaultAccId).FirstAsync();
            accList.Add(new SelectListItem { Text = defaultObj.Description + "," + defaultObj.Id.ToString(), Value = defaultObj.Id.ToString() });

            var list = await(from item in dbCon.BasicCoa
                             join iden in dbCon.BasicCoa on item.ParentId equals (int)iden.Id
                             join narrow in dbCon.BasicCoa on iden.ParentId equals (int)narrow.Id
                             join broadgroup in dbCon.BasicCoa on narrow.ParentId equals (int)broadgroup.Id
                             join sab in dbCon.BasicCoa on broadgroup.ParentId equals (int)sab.Id
                             join cat in dbCon.BasicCoa on sab.ParentId equals (int)cat.Id
                             join com in dbCon.BasicCoa on cat.ParentId equals (int)com.Id
                             where iden.Description == "Advance Income Tax" && com.Id == companyId
                             select (new SelectListItem
                             {
                                 Text = item.Description + "," + item.Id,
                                 Value = item.Id.ToString()
                             })).ToListAsync();
            accList.AddRange(list);
            return accList;
        }

        public async Task<UserInfoModel> GetACCUserCompany(string UserName)
        {
            var _userTbl =
                  from u in dbCon.User
                  join c in dbCon.CompanyInfo on u.CompId.Value equals (int)c.CompanyId into compTbl
                  from c in compTbl.DefaultIfEmpty()
                  where u.Name.ToLower() == UserName.ToLower()
                  select new UserInfoModel
                  {
                      UserName = u.Name,
                      CompanyID = c == null ? 0 : Convert.ToInt64(c.CompanyId),
                      CompanyName = c == null ? "" : c.Companyname
                  };
            var userInfo = await _userTbl.FirstOrDefaultAsync();
            return userInfo;
            
        }
    }
}
