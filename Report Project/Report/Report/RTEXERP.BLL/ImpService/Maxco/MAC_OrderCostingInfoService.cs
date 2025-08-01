using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class MAC_OrderCostingInfoService : IMAC_OrderCostingInfoService
    {
        private readonly IMAC_OrderCostingInfoRepository mAC_OrderCostingInfoRepository;
        private readonly IMapper mapper;
        public MAC_OrderCostingInfoService(IMAC_OrderCostingInfoRepository mAC_OrderCostingInfoRepository, IMapper mapper)
        {
            this.mAC_OrderCostingInfoRepository = mAC_OrderCostingInfoRepository;
            this.mapper = mapper;
        }

        public async Task<List<SelectListItem>> DDLOrder(int BuyerID)
        {
            return await mAC_OrderCostingInfoRepository.DDLOrder(BuyerID);
        }

        public async Task<List<SelectListItem>> DDLStyle(string OrderName)
        {
            return await mAC_OrderCostingInfoRepository.DDLStyle(OrderName);
        }

        public async Task<List<BasicModel>> GETFabricComposition(string Composition)
        {
            return await mAC_OrderCostingInfoRepository.GETFabricComposition(Composition);
        }

        public async Task<List<Vw_MAC_IndirectCostingItem>> GetIndirectCostingItem()
        {
            return await this.mAC_OrderCostingInfoRepository.GetIndirectCostingItem();
        }

        public async Task<MAC_OrderCostingInfoVM> GetOrderCostingInfoByIDForClone(int CostingID)
        {
            return await this.mAC_OrderCostingInfoRepository.GetOrderCostingInfoByIDForClone(CostingID);
        }

        public async Task<List<MAC_GetOrderCostingListSPModel>> MAC_GetInaciveOrderCostingList(int OrderCostingID = 0, int? BuyerID = 0, string OrderNo = null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            return await mAC_OrderCostingInfoRepository.MAC_GetInaciveOrderCostingList(OrderCostingID, BuyerID, OrderNo, StyleName, FabricInfo, DateFrom, DateTo);
        }

        public async Task<List<MAC_GetOrderCostingListSPModel>> MAC_GetOrderCostingList(int OrderCostingID = 0, int? BuyerID = 0,string OrderNo=null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            return await mAC_OrderCostingInfoRepository.MAC_GetOrderCostingList(OrderCostingID,BuyerID, OrderNo,StyleName, FabricInfo, DateFrom, DateTo);
        }

        public async Task<RResult> OrderCostingSave(MAC_OrderCostingInfoVM model,int CreateBy)
        {

            var entity = mapper.Map<MAC_OrderCostingInfoVM, MAC_OrderCostingInfo>(model);

            entity.CreatedBy = CreateBy;
            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;
            entity.IsRemvoed = false;
            entity.MAC_AccessoriesCostingInfo.ForEach(b => { b.IsRemvoed = false; b.IsActive = true; b.CreatedBy = CreateBy; b.CreatedDate = DateTime.Now; });
            entity.MAC_FabricCostingInfo.ForEach(b => { b.IsRemvoed = false; b.IsActive = true; b.CreatedBy = CreateBy; b.CreatedDate = DateTime.Now; });
            var res = await this.mAC_OrderCostingInfoRepository.OrderCostingSave(entity);
            return res;
        }
        public async Task<RResult> OrderCostingUpdate(MAC_OrderCostingInfoVM model, int CreateBy)
        {
            var res = await this.mAC_OrderCostingInfoRepository.OrderCostingUpdate(model,CreateBy);
            return res;
        }
        

        public async Task<List<BasicModel>> OrderDirectAccessoriesCostItem(int? TrimID, string Search)
        {
            return await mAC_OrderCostingInfoRepository.OrderDirectAccessoriesCostItem(TrimID, Search);
        }

        public async Task<RResult> RemoveCostingSheet(int ID, string Remarks, int CreateBy)
        {
            return await this.mAC_OrderCostingInfoRepository.RemoveCostingSheet(ID, Remarks,CreateBy);
        }
    }
}
