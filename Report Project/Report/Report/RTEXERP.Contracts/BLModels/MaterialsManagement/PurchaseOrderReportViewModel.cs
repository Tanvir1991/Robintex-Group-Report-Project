using RTEXERP.Contracts.BLModels.MaterialsManagement.AttributeInfo;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class PurchaseOrderReportViewModel
    {
        public PurchaseOrderReportViewModel()
        {
            POInfo = new DD_PO_PurchaseOrderInfoSPModel();
            DD_PO_PurchaseOrderDetailsInfo = new List<DD_PO_PurchaseOrderDetailsInfoSPModel>();
            POMRPItemList = new List<POMRPItem>();
        }
        public DD_PO_PurchaseOrderInfoSPModel POInfo { get; set; }

        public List<DD_PO_PurchaseOrderDetailsInfoSPModel> DD_PO_PurchaseOrderDetailsInfo { get; set; }

        public List<POMRPItem> POMRPItemList { get; set; }
        public int ShowStyleWise { get; set; }
        



    }

    public class POMRPItem
    {
        public POMRPItem()
        {
            HighLevel = new List<AttributeHighLevelGroup>();
        }
        public int MRPItemCode { get; set; }
        public string MRPItemName { get; set; }

        public decimal TotalQuantity { get; set; }
        public string UnitName { get; set; }

        public decimal TotalAmount { get; set; }
        public List<AttributeHighLevelGroup> HighLevel { get; set; }

    }
    public class AttributeHighLevelGroup
    {
        public AttributeHighLevelGroup()
        {
            HighAttributeRow = new List<ShowAttribute>();
            LowLevelList = new List<AttributeLowLevelGroup>();
        }
        public int SL { get; set; }
        public List<ShowAttribute> HighAttributeRow { get; set; }

        public List<AttributeLowLevelGroup> LowLevelList { get; set; }
    }

    public class AttributeLowLevelGroup
    {
        public AttributeLowLevelGroup()
        {
            LowAttribute = new List<ShowAttribute>();
            StyleGarmentsSizeQuantity = new List<OrderGarmentAssortmentOrder_StyeAndSizeSPModel>();
        }
        public int SL { get; set; }
        public int OrderQuantity { get; set; }
        public string UnitName { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryPoint { get; set; }
        public decimal UnitPrice { get; set; }
        public string SelectedCurrency { get; set; }
        public decimal OrderedQtyAmount { get; set; }
        public string RequisitionNumber { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal CurrencyRate { get; set; }
        public string StyleName { get; set; }
        public int ModelID { get; set; }
        public List<ShowAttribute> LowAttribute { get; set; }
        public List<OrderGarmentAssortmentOrder_StyeAndSizeSPModel> StyleGarmentsSizeQuantity { get; set; }
    }

    public class ShowAttribute
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string ValueDescription { get; set; }
        public int Priority { get; set; }
        public string Text { get; set; }
    }



}
