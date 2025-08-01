using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class CMBL_ItemAttributeRepository:GenericRepository<CMBL_ItemAttribute>, ICMBL_ItemAttributeRepository
    {
        private MaterialsManagementDBContext dbCon;
        public CMBL_ItemAttributeRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroupOne(int companyID, int userId)
        {
            
            var list = await (from ia in dbCon.CMBL_ItemAttribute
                              join sbg in dbCon.CMBL_StoreBroadGroup on ia.AttributeID equals sbg.AttributeID
                              join us in dbCon.CMBL_UserStore on sbg.StoreID equals us.StoreID
                              where ia.AttributeLevel == 1 && ia.CompanyID == companyID && us.UserID == userId
                              select new SelectListItem()
                              {
                                  Text = ia.AttributeName,
                                  Value = ia.AttributeID.ToString()
                              }).ToListAsync();
            var finalData = list.GroupBy(b => new { b.Text, b.Value })
                .Select(x => new SelectListItem
                {
                    Text = x.Key.Text,
                    Value = x.Key.Value
                }).ToList();
            return finalData;

        }



        //public async Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroupTwo(int parentAttributeID)
        //{
        //    var broadGrouptwoList = await dbCon.CMBL_ItemAttribute.Where(b => b.ParentAttributeID == parentAttributeID && b.AttributeLevel==2)
        //        .GroupBy(b => new { b.AttributeID, b.AttributeName })
        //        .Select(x => new SelectListItem()
        //        {
        //            Text = x.Key.AttributeName,
        //            Value = x.Key.AttributeID.ToString()
        //        }).ToListAsync();
        //    broadGrouptwoList.OrderByDescending(b => b.Value);
        //    return broadGrouptwoList;
        //}
        public async Task<List<SelectListItem>> GetDDLCMBLItemAttributeBroadGroup(int parentAttributeID ,int attributeLevel)
        {
            var broadGroupthreeList = await dbCon.CMBL_ItemAttribute.Where(b => b.ParentAttributeID == parentAttributeID && b.AttributeLevel == attributeLevel)
                .GroupBy(b => new { b.AttributeID, b.AttributeName })
                .Select(x => new SelectListItem()
                {
                    Text = x.Key.AttributeName,
                    Value = x.Key.AttributeID.ToString()
                }).ToListAsync();
            broadGroupthreeList.OrderByDescending(b => b.Value);
            return broadGroupthreeList;
        }

        public async Task<List<SelectListItem>> GetDDLCMBLItemAttributeByParentID(int parentAttributeID)
        {

            var list = await (from itemone in dbCon.CMBL_ItemAttribute
                              join itemtwo in dbCon.CMBL_ItemAttribute on itemone.AttributeID equals itemtwo.ParentAttributeID
                              join itemthree in dbCon.CMBL_ItemAttribute on itemtwo.AttributeID equals itemthree.ParentAttributeID
                             join itm in dbCon.CMBL_Item on itemthree.AttributeID equals itm.LowestAttributeID
                              where   itemone.ParentAttributeID == parentAttributeID
                              select new SelectListItem()
                              {
                                  Text = itm.ItemName,
                                  Value = itm.ItemID.ToString()
                              }).ToListAsync();

            var finalData = list.GroupBy(b => new { b.Text, b.Value })
                .Select(x => new SelectListItem
                {
                    Text = x.Key.Text,
                    Value = x.Key.Value
                }).ToList();
            return finalData;

        }

    }
}
