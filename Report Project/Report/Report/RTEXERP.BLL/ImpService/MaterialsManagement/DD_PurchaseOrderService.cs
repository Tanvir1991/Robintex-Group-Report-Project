using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.MaterialsManagement.AttributeInfo;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class DD_PurchaseOrderService : IDD_PurchaseOrderService
    {
        private readonly IDD_PurchaseOrderRepository dd_PurchaseOrderRepository;
        private readonly IMM_MRPItemAttributeInstanceRepository AttributeInstanceInfo;
        private readonly IOrderGarmentAssortmentOrderRepository orderGarmentAssortmentOrderRepository;
        public DD_PurchaseOrderService(IDD_PurchaseOrderRepository _dd_PurchaseOrderRepository, IMM_MRPItemAttributeInstanceRepository _AttributeInstanceInfo
            , IOrderGarmentAssortmentOrderRepository _orderGarmentAssortmentOrderRepository)
        {
            dd_PurchaseOrderRepository = _dd_PurchaseOrderRepository;
            AttributeInstanceInfo = _AttributeInstanceInfo;
            orderGarmentAssortmentOrderRepository = _orderGarmentAssortmentOrderRepository;
        }

        public async Task<List<SelectListItem>> DDLPurchaseOrder(int OrderID, DateTime? PODateFrom = null, DateTime? PODateTo = null)
        {
            return await dd_PurchaseOrderRepository.DDLPurchaseOrder(OrderID, PODateFrom, PODateTo);
        }
        public async Task<List<SelectListItem>> DDLPurchaseOrderStatus()
        {
            return await dd_PurchaseOrderRepository.DDLPurchaseOrderStatus();
        }

        public async Task<List<DD_PO_PurchaseOrderDetailsInfoSPModel>> GetDD_PO_PurchaseOrderDetailsInfo(int POID)
        {
            return await dd_PurchaseOrderRepository.GetDD_PO_PurchaseOrderDetailsInfo(POID);
        }

        public async Task<DD_PO_PurchaseOrderInfoSPModel> GetDD_PO_PurchaseOrderInfo(int POID)
        {
            return await dd_PurchaseOrderRepository.GetDD_PO_PurchaseOrderInfo(POID);
        }

        public async Task<List<GetOrderPOListSPModel>> GetOrderPOList(int OrderID = 0, int POID = 0, DateTime? PODateFrom = null, DateTime? PODateTo = null, int StatusID = 0)
        {
            return await dd_PurchaseOrderRepository.GetOrderPOList(OrderID, POID, PODateFrom, PODateTo, StatusID);
        }

        public async Task<PurchaseOrderReportViewModel> GetPOReport(int POID, int IsShowStyleSizeWiseQuantity)
        {
            PurchaseOrderReportViewModel rtnModel = new PurchaseOrderReportViewModel();
            rtnModel.POInfo = await dd_PurchaseOrderRepository.GetDD_PO_PurchaseOrderInfo(POID);
            var detailsModel = await dd_PurchaseOrderRepository.GetDD_PO_PurchaseOrderDetailsInfo(POID);
            List<POMRPItem> POMRPItemList = new List<POMRPItem>();
         //   List<OrderGarmentAssortmentOrder_StyeAndSizeSPModel> StyleGarmentsSizeQuantity;
            foreach (var poItem in detailsModel)
            {
                var attributesinfo = await AttributeInstanceInfo.GetForAttributeInstanceXMLToObject(poItem.AttributeInstanceID);
                poItem.MRPAttributes = attributesinfo;
                var highLevelAttribute = getAttribute(attributesinfo, 1);
                var LowLevelAttribute = getAttribute(attributesinfo, 0);

          

                POMRPItem pOMRPItem = new POMRPItem();
                var isExistMRP = POMRPItemList.Where(b => b.MRPItemCode == poItem.MRPItemCode && b.UnitName == poItem.UnitName).FirstOrDefault();
                if (isExistMRP == null)
                {
                    pOMRPItem.MRPItemCode = poItem.MRPItemCode;
                    pOMRPItem.MRPItemName = poItem.MRPItemName;
                    pOMRPItem.TotalQuantity = poItem.OrderedQty;
                    pOMRPItem.UnitName = poItem.UnitName;
                    pOMRPItem.TotalAmount += poItem.OrderedQtyAmount / poItem.CurrencyRate;

                    AttributeHighLevelGroup highlevel = new AttributeHighLevelGroup();
                    highlevel.SL = 1;
                    highlevel.HighAttributeRow = highLevelAttribute;


                    AttributeLowLevelGroup lowlevelGroup = new AttributeLowLevelGroup();
                    lowlevelGroup.SL = 1;
                    lowlevelGroup.OrderQuantity = poItem.OrderedQty;
                    lowlevelGroup.UnitName = poItem.UnitName;
                    lowlevelGroup.DeliveryDate = poItem.DeliveryDate;
                    lowlevelGroup.DeliveryPoint = poItem.DeliveryLocation;
                    lowlevelGroup.UnitPrice = poItem.UnitPrice/poItem.CurrencyRate;
                    lowlevelGroup.SelectedCurrency = poItem.CurrencyName;
                    lowlevelGroup.OrderedQtyAmount = poItem.OrderedQtyAmount / poItem.CurrencyRate;
                    lowlevelGroup.CurrencySymbol = poItem.CurrencySymbol;
                    lowlevelGroup.RequisitionNumber = poItem.ReqNo;

                    lowlevelGroup.LowAttribute = LowLevelAttribute;
                    #region if show Style Garments Size
                    if (IsShowStyleSizeWiseQuantity > 0)
                    { 
                        lowlevelGroup.StyleGarmentsSizeQuantity = await orderGarmentAssortmentOrderRepository.Get_OrderGarmentAssortmentOrder_StyeAndSize(poItem.ModelID);
                    }
                    #endregion
 
                    highlevel.LowLevelList.Add(lowlevelGroup);

                    pOMRPItem.HighLevel.Add(highlevel);

                    POMRPItemList.Add(pOMRPItem);
                }
                else
                {
                    isExistMRP.TotalQuantity += poItem.OrderedQty;
                    isExistMRP.TotalAmount += poItem.OrderedQtyAmount / poItem.CurrencyRate;
                    pOMRPItem = isExistMRP;

                    var IsSameAsHighLevel = SameAsHighLevel(pOMRPItem, poItem);
                    if (IsSameAsHighLevel > 0)
                    {
                        var highLevelData = pOMRPItem.HighLevel.Where(b => b.SL == IsSameAsHighLevel).FirstOrDefault();
                        var isSameAsLowLevel = SameAsLowLevel(highLevelData, poItem);
                        if (isSameAsLowLevel == 1 && IsShowStyleSizeWiseQuantity==0)
                        {
                            var lowlevelQuantity = highLevelData.LowLevelList.Where(s => s.SL == isSameAsLowLevel).FirstOrDefault();
                            lowlevelQuantity.OrderQuantity += poItem.OrderedQty;
                            lowlevelQuantity.OrderedQtyAmount += (poItem.OrderedQty * poItem.UnitPrice) / poItem.CurrencyRate;
                        }
                        else
                        {

                            AttributeLowLevelGroup lowlevelGroup = new AttributeLowLevelGroup();
                            lowlevelGroup.SL = 1;
                            lowlevelGroup.OrderQuantity = poItem.OrderedQty;
                            lowlevelGroup.UnitName = poItem.UnitName;
                            lowlevelGroup.DeliveryDate = poItem.DeliveryDate;
                            lowlevelGroup.DeliveryPoint = poItem.DeliveryLocation;
                            lowlevelGroup.UnitPrice = poItem.UnitPrice / poItem.CurrencyRate;
                            lowlevelGroup.SelectedCurrency = poItem.CurrencyName;
                            lowlevelGroup.OrderedQtyAmount = poItem.OrderedQtyAmount / poItem.CurrencyRate;
                            lowlevelGroup.CurrencySymbol = poItem.CurrencySymbol;
                            lowlevelGroup.RequisitionNumber = poItem.ReqNo;

                            lowlevelGroup.LowAttribute = LowLevelAttribute;

                            #region if show Style Garments Size
                            if (IsShowStyleSizeWiseQuantity > 0)
                            {
                                lowlevelGroup.StyleGarmentsSizeQuantity = await orderGarmentAssortmentOrderRepository.Get_OrderGarmentAssortmentOrder_StyeAndSize(poItem.ModelID);
                            }
                            #endregion

                            highLevelData.LowLevelList.Add(lowlevelGroup);
                        }
                    }
                    else
                    {

                        AttributeHighLevelGroup highlevel = new AttributeHighLevelGroup();
                        highlevel.SL = pOMRPItem.HighLevel.Count() + 1;
                        highlevel.HighAttributeRow = highLevelAttribute;


                        AttributeLowLevelGroup lowlevelGroup = new AttributeLowLevelGroup();
                        lowlevelGroup.SL = 1;
                        lowlevelGroup.OrderQuantity = poItem.OrderedQty;
                        lowlevelGroup.UnitName = poItem.UnitName;
                        lowlevelGroup.DeliveryDate = poItem.DeliveryDate;
                        lowlevelGroup.DeliveryPoint = poItem.DeliveryLocation;
                        lowlevelGroup.UnitPrice = poItem.UnitPrice/poItem.CurrencyRate;
                        lowlevelGroup.SelectedCurrency = poItem.CurrencyName;
                        lowlevelGroup.OrderedQtyAmount = poItem.OrderedQtyAmount / poItem.CurrencyRate;
                        lowlevelGroup.CurrencySymbol = poItem.CurrencySymbol;
                        lowlevelGroup.RequisitionNumber = poItem.ReqNo;
                        lowlevelGroup.CurrencyRate = poItem.CurrencyRate;
                        lowlevelGroup.LowAttribute = LowLevelAttribute;

                        #region if show Style Garments Size
                        if (IsShowStyleSizeWiseQuantity > 0)
                        {
                            lowlevelGroup.StyleGarmentsSizeQuantity = await orderGarmentAssortmentOrderRepository.Get_OrderGarmentAssortmentOrder_StyeAndSize(poItem.ModelID);
                        }
                        #endregion

                        highlevel.LowLevelList.Add(lowlevelGroup);

                        pOMRPItem.HighLevel.Add(highlevel);

                    }
                }


            }
            rtnModel.POMRPItemList = POMRPItemList;
            return rtnModel;
        }






        private int SameAsHighLevel(POMRPItem poMrpItem, DD_PO_PurchaseOrderDetailsInfoSPModel dbrowData)
        {
            int sl = 0;
            foreach (var existingPoHighLevel in poMrpItem.HighLevel)
            {
                var itemHighLevel = getAttribute(dbrowData.MRPAttributes, 1);
                var exHighLevel = existingPoHighLevel.HighAttributeRow;
                var isExistingHighLevel = IsSameAttributeList(exHighLevel, itemHighLevel);
                if (isExistingHighLevel)
                {
                    sl = existingPoHighLevel.SL;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return sl;

        }
        private int SameAsLowLevel(AttributeHighLevelGroup LowLevelRow, DD_PO_PurchaseOrderDetailsInfoSPModel dbrowData)
        {
            int sl = 0;
            foreach (var existingPoHighLevel in LowLevelRow.LowLevelList)
            {
                var itemLowLevel = getAttribute(dbrowData.MRPAttributes, 0);

                var isExistingHighLevel = IsSameAttributeList(existingPoHighLevel.LowAttribute, itemLowLevel);
                if (isExistingHighLevel)
                {
                    sl = existingPoHighLevel.SL;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return sl;

        }

        private List<ShowAttribute> getAttribute(MRPAttributes attributes, int HighOrLowLevel)
        {
            var neededAttribute = attributes.MRPAttribute
                                 .Where(b => b.IsHighLevel == HighOrLowLevel)
                                 .Select(s => new ShowAttribute
                                 {
                                     ID = s.ID,
                                     Name = s.Name,
                                     Priority = s.Priority,
                                     Text = s.Text,
                                     ValueDescription = s.ValueDescription
                                 }).ToList();
            return neededAttribute;
        }

        private bool IsSameAttributeList(List<ShowAttribute> first, List<ShowAttribute> Second)
        {
            bool isUnique = true;
            if (first.Count != Second.Count)
            {
                return false;
            }
            foreach (var f in first)
            {

                var checkSecondData = Second.Where(s => s.ID == f.ID
                                                  && s.Name == f.Name
                                                  && s.Priority == f.Priority
                                                  && s.Text == f.Text
                                                  && s.ValueDescription == f.ValueDescription
                                                 ).FirstOrDefault();
                if (checkSecondData == null)
                {
                    isUnique = false;
                    break;
                }

            }

            return isUnique;

        }
    }
}
