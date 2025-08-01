using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class MAC_OrderCostingInfoRepository : GenericRepository<MAC_OrderCostingInfo>, IMAC_OrderCostingInfoRepository
    {
        private MaxcoDBContext dbCon;
        private readonly IMapper mapper;

        public MAC_OrderCostingInfoRepository(MaxcoDBContext context, IMapper _mapper)
            : base(context)
        {
            dbCon = context;
            mapper = _mapper;

        }
        public async Task<List<BasicModel>> GETFabricComposition(string Composition)
        {
            var itemList = new List<BasicModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.USP_GETFabricComposition")
                             .WithSqlParam("Composition", Composition)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<BasicModel>() as List<BasicModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Vw_MAC_IndirectCostingItem>> GetIndirectCostingItem()
        {
            var itemList = new List<Vw_MAC_IndirectCostingItem>();
            try
            {
                itemList = await dbCon.Vw_MAC_IndirectCostingItem.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return itemList;
        }

        public async Task<List<BasicModel>> OrderDirectAccessoriesCostItem(int? TrimID, string Search)
        {
            var itemList = new List<BasicModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.MAC_GetAccessoriesType")
                             .WithSqlParam("TrimID", TrimID)
                             .WithSqlParam("Search", Search)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<BasicModel>() as List<BasicModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<RResult> OrderCostingSave(MAC_OrderCostingInfo model)
        {
            RResult rResult = new RResult();
            rResult.result = 0;
            try
            {
                var isDuplicate = await dbCon.MAC_OrderCostingInfo.Where(b => b.OrderNo == model.OrderNo
                 && b.BuyerID == model.BuyerID && b.IsRemvoed == false)
                    .ToListAsync();
                if (isDuplicate.Count > 0)
                {
                    rResult.result = 0;
                    rResult.message = "Order no is exist.";
                    return rResult;
                }
                dbCon.MAC_OrderCostingInfo.Add(model);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = "Successfully Add.";

            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = "Problem face.";
            }
            return rResult;
        }
        public async Task<RResult> OrderCostingUpdate(MAC_OrderCostingInfoVM model, int CreateBy)
        {
            RResult rResult = new RResult();
            rResult.result = 0;
            try
            {
                var isDuplicate = await dbCon.MAC_OrderCostingInfo.Where(b => b.OrderNo == model.OrderNo
                 && b.BuyerID == model.BuyerID && b.IsRemvoed == false && b.ID != model.ID)
                    .ToListAsync();
                if (isDuplicate.Count > 0)
                {
                    rResult.result = 0;
                    rResult.message = "Order no is exist.";
                    return rResult;
                }
                var orderInfo = await dbCon.MAC_OrderCostingInfo.FindAsync(model.ID);
                orderInfo.UpdatedBY = CreateBy;
                orderInfo.UpdatedDate = DateTime.Now;
                orderInfo.BuyerID = model.BuyerID;
                orderInfo.OrderNo = model.OrderNo;
                orderInfo.StyleName = model.StyleName;
                orderInfo.OrderQuantity = model.OrderQuantity;
                orderInfo.BackCalculationPercent = model.BackCalculationPercent;
                orderInfo.FabricConsumptionPerDzn = model.FabricConsumptionPerDzn;
                orderInfo.SMV = model.SMV;
                orderInfo.CPM = model.CPM;
                orderInfo.Efficiency = model.Efficiency;

                var dbFabric = await dbCon.MAC_FabricCostingInfo.Where(b => b.OrderCostingID == model.ID).ToListAsync();

                #region Fabric Remove
                foreach (var fab in dbFabric)
                {
                    var currentObj = model.MAC_FabricCostingInfo.Where(b => b.ID == fab.ID).FirstOrDefault();
                    if (currentObj == null)
                    {
                        fab.IsRemvoed = true;
                        fab.UpdatedBY = CreateBy;
                        fab.UpdatedDate = DateTime.Now;
                        dbCon.MAC_FabricCostingInfo.Update(fab);
                    }

                }
                #endregion Fabric Remove
                #region Fabric Add
                foreach (var fab in model.MAC_FabricCostingInfo.Where(b => b.ID == 0).ToList())
                {
                    var dbFabObj = mapper.Map<MAC_FabricCostingInfoVM, MAC_FabricCostingInfo>(fab);
                    dbFabObj.CreatedBy = CreateBy;
                    dbFabObj.IsRemvoed = false;
                    dbFabObj.IsActive = true;
                    dbFabObj.CreatedDate = DateTime.Now;
                    orderInfo.MAC_FabricCostingInfo.Add(dbFabObj);
                }
                #endregion Fabric Add
                #region Trim UPdate and Remove
                var dbTrim = await dbCon.MAC_AccessoriesCostingInfo.Where(b => b.OrderCostingID == model.ID).ToListAsync();
                foreach (var trim in dbTrim)
                {
                    var currentObj = model.MAC_AccessoriesCostingInfo.Where(b => b.ID == trim.ID).FirstOrDefault();
                    if (currentObj == null)
                    {
                        trim.IsRemvoed = true;
                        trim.UpdatedBY = CreateBy;
                        trim.UpdatedDate = DateTime.Now;
                        dbCon.MAC_AccessoriesCostingInfo.Update(trim);
                    }
                    else
                    {
                        trim.CostRate = currentObj.CostRate;
                        trim.UpdatedBY = CreateBy;
                        trim.UpdatedDate = DateTime.Now;
                    }
                }
                #endregion

                #region Trim Add
                foreach (var _trim in model.MAC_AccessoriesCostingInfo.Where(b => b.ID == 0).ToList())
                {
                    var _NewTrim = mapper.Map<MAC_AccessoriesCostingInfoVM, MAC_AccessoriesCostingInfo>(_trim);
                    _NewTrim.CreatedBy = CreateBy;
                    _NewTrim.IsRemvoed = false;
                    _NewTrim.IsActive = true;
                    _NewTrim.CreatedDate = DateTime.Now;
                    orderInfo.MAC_AccessoriesCostingInfo.Add(_NewTrim);
                }
                #endregion

                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = "Successfully update.";

            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = "Problem face.";
            }
            return rResult;
        }

        public async Task<List<MAC_GetOrderCostingListSPModel>> MAC_GetOrderCostingList(int OrderCostingID = 0, int? BuyerID = 0, string OrderNo = null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var itemList = new List<MAC_GetOrderCostingListSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.MAC_GetOrderCostingList")
                             .WithSqlParam("OrderCostingID", OrderCostingID)
                             .WithSqlParam("BuyerID", BuyerID)
                             .WithSqlParam("OrderNo", OrderNo)
                             .WithSqlParam("StyleName", StyleName)
                             .WithSqlParam("FabricInfo", FabricInfo)
                             .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                             .WithSqlParam("IsRemvoed",false)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<MAC_GetOrderCostingListSPModel>() as List<MAC_GetOrderCostingListSPModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<MAC_GetOrderCostingListSPModel>> MAC_GetInaciveOrderCostingList(int OrderCostingID = 0, int? BuyerID = 0, string OrderNo = null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var itemList = new List<MAC_GetOrderCostingListSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.MAC_GetOrderCostingList")
                             .WithSqlParam("OrderCostingID", OrderCostingID)
                             .WithSqlParam("BuyerID", BuyerID)
                             .WithSqlParam("OrderNo", OrderNo)
                             .WithSqlParam("StyleName", StyleName)
                             .WithSqlParam("FabricInfo", FabricInfo)
                             .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                             .WithSqlParam("IsRemvoed", true)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<MAC_GetOrderCostingListSPModel>() as List<MAC_GetOrderCostingListSPModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<SelectListItem>> DDLOrder(int BuyerID)
        {
            var list = await dbCon.MAC_OrderCostingInfo
                           .Where(b => b.IsRemvoed == false && b.BuyerID == BuyerID)
                           .Select(b => new SelectListItem
                           {
                               Text = b.OrderNo,
                               Value = b.OrderNo
                           }).ToListAsync();
            return list;
        }

        public async Task<List<SelectListItem>> DDLStyle(string OrderName)
        {
            var list = await dbCon.MAC_OrderCostingInfo
                        .Where(b => b.IsRemvoed == false && b.OrderNo == OrderName)
                        .Select(b => new SelectListItem
                        {
                            Text = b.StyleName,
                            Value = b.StyleName
                        }).ToListAsync();
            return list;
        }

        public async Task<MAC_OrderCostingInfoVM> GetOrderCostingInfoByIDForClone(int CostingID)
        {
            var model = new MAC_OrderCostingInfoVM();
            try
            {
                model = await (from oc in dbCon.MAC_OrderCostingInfo
                               join b in dbCon.Buyer_Setup on oc.BuyerID equals b.ID
                               where oc.ID == CostingID
                               select new MAC_OrderCostingInfoVM
                               {
                                   ID = oc.ID,
                                   CostingDate = oc.CostingDate,
                                   BuyerID = oc.BuyerID.Value,
                                   BuyerName = b.Description.Trim(),
                                   OrderNo = oc.OrderNo,
                                   StyleName = oc.StyleName,
                                   OrderQuantity = oc.OrderQuantity,
                                   SMV = oc.SMV.Value,
                                   BackCalculationPercent = oc.BackCalculationPercent.Value,
                                   FabricConsumptionPerDzn = oc.FabricConsumptionPerDzn.Value,
                                   Efficiency = oc.Efficiency

                               }).FirstAsync();
                var fabric = await (from f in dbCon.MAC_FabricCostingInfo
                                    join fq in dbCon.FabricQuality_Setup on f.FabricQualityID equals fq.ID
                                    where f.OrderCostingID == CostingID && f.IsRemvoed == false && f.IsActive == true
                                    select new MAC_FabricCostingInfoVM
                                    {
                                        ID = f.ID,
                                        OrderCostingID = f.OrderCostingID,
                                        FabricCompisition = f.FabricCompisition,
                                        GSM = f.GSM.Value,
                                        FabricQualityID = f.FabricQualityID.Value,
                                        FabricQuality = fq.Description.Trim(),
                                        YarnCount = f.YarnCount,
                                        FabricColor = f.FabricColor,
                                        YarnPrice = f.YarnPrice.Value,
                                        LycraCostPercent = f.LycraCostPercent.Value,
                                        LycraCost = f.LycraCost.Value,
                                        KnittingCost = f.KnittingCost.Value,
                                        KnittingWastagePer = f.KnittingWastagePer.Value,
                                        DeyingCostSolid = f.DeyingCostSolid.Value,
                                        DeyingWastagePer = f.DeyingWastagePer.Value,
                                        LeveragePercent = f.LeveragePercent.Value
                                    }).ToListAsync();

                model.MAC_FabricCostingInfo = fabric;

                var orderTrim = await dbCon.MAC_AccessoriesCostingInfo
                                           .Where(b => b.OrderCostingID == CostingID
                                                         && b.IsRemvoed == false
                                                         && b.IsActive == true)
                                           .Select(b => new MAC_AccessoriesCostingInfoVM
                                           {
                                               ID = b.ID,
                                               OrderCostingID = b.OrderCostingID,
                                               TrimID = b.TrimID,
                                               CostingItemID = b.CostingItemID,
                                               CostingTypeID = b.CostingTypeID,
                                               CostingFor = b.CostingFor,
                                               CostRate = b.CostRate
                                           }).ToListAsync();

                model.MAC_AccessoriesCostingInfo = orderTrim;

                return model;
            }
            catch (Exception e)
            {
                throw new Exception("Problem arise when  data receive");
            }
        }

        public async Task<MAC_OrderCostingInfo> GetMAC_OrderCostingInfoByOrderNo(string orderNo)
        {
            var entity = await dbCon.MAC_OrderCostingInfo
                .Include(x => x.MAC_AccessoriesCostingInfo)
                .Where(x => x.OrderNo == orderNo && x.IsActive == true && x.IsRemvoed == false).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<List<SelectListItem>> DDLCostingOrder(int? BuyerID, DateTime? DateFrom, DateTime? DateTo)
        {
            try
            {
                var data = dbCon.MAC_OrderCostingInfo
                         .Where(b => b.IsRemvoed == false && b.IsActive == true);
                if (BuyerID.HasValue == true && BuyerID.Value > 0)
                {
                    data = data.Where(b => b.BuyerID == BuyerID);
                }
                if (DateFrom.HasValue == true && DateTo.HasValue == true)
                {
                    data = data.Where(b => b.CostingDate.Date > DateFrom.Value.Date
                                           && b.CostingDate <= DateTo.Value.Date);
                }

                var _data = await data.Select(b => new SelectListItem
                {
                    Text = b.ID.ToString(),
                    Value = b.OrderNo
                }).ToListAsync();
                return _data;
            }
            catch (Exception e)
            {
                throw new Exception("Not found");
            }
        }

        public async Task<RResult> RemoveCostingSheet(int ID, string Remarks, int UpdateBy)
        {
            RResult rResult = new RResult();
            try
            {
                var master = await dbCon.MAC_OrderCostingInfo
                                        .Include(b => b.MAC_FabricCostingInfo)
                                        .Include(b => b.MAC_AccessoriesCostingInfo)
                                       .Where(b => b.IsRemvoed == false && b.IsActive == true && b.ID == ID).FirstOrDefaultAsync();
                if (master == null)
                {
                    rResult.result = 0;
                    rResult.message = "Order is not found";
                    return rResult;
                }
                master.UpdatedBY = UpdateBy;
                master.IsRemvoed = true;
                master.UpdatedDate = DateTime.Now;
                master.Remarks = Remarks;
                foreach (var t in master.MAC_AccessoriesCostingInfo)
                {
                    t.IsRemvoed = true;
                    t.UpdatedBY = UpdateBy;
                    t.UpdatedDate = DateTime.Now;
                }
                foreach (var f in master.MAC_FabricCostingInfo)
                {
                    f.IsRemvoed = true;
                    f.UpdatedBY = UpdateBy;
                    f.UpdatedDate = DateTime.Now;
                }

                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = "Successfully Deleted.";

                return rResult;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = "Invalid.";
                return rResult;
            }

        }
    }
}
