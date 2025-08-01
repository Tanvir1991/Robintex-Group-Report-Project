using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class TblOrdershipmentstatusOfs
    {
        public long Id { get; set; }
        public long? Buyerid { get; set; }
        public string Buyername { get; set; }
        public long StyleOrderId { get; set; }
        public string StyleOrderNo { get; set; }
        public string Companyname { get; set; }
        public byte? MonthNo { get; set; }
        public int? Year { get; set; }
        public long? ShippedQty { get; set; }
        public double? TotalYarnRate { get; set; }
        public double? KnittingRate { get; set; }
        public double? GreigeFabricCost { get; set; }
        public double FinishFabricCost { get; set; }
        public double? FinishFabricConsumption { get; set; }
        public long? OrderQty { get; set; }
        public long Fid { get; set; }
        public long ForderSheetId { get; set; }
        public long ForderId { get; set; }
        public long? ForderQty { get; set; }
        public double? FfinishFabric { get; set; }
        public double? FtotalTrimCost { get; set; }
        public double? FembroPrintCost { get; set; }
        public double? Fcm { get; set; }
        public double? FotherAllowanceCost { get; set; }
        public double? Fcommission { get; set; }
        public double? FavgNegotiatedPrice { get; set; }
        public double? FavgCostingPrice { get; set; }
        public double? Fconsumption { get; set; }
        public long Lid { get; set; }
        public long LorderSheetId { get; set; }
        public long LorderId { get; set; }
        public long? LorderQty { get; set; }
        public double? LfinishFabric { get; set; }
        public double? LtotalTrimCost { get; set; }
        public double? LembroPrintCost { get; set; }
        public double? Lcm { get; set; }
        public double? LotherAllowanceCost { get; set; }
        public double? Lcommission { get; set; }
        public double? LavgNegotiatedPrice { get; set; }
        public double? LavgCostingPrice { get; set; }
        public double? Lconsumption { get; set; }
        public long? Yarnorderid { get; set; }
        public double? Yarnissuerate { get; set; }
        public double? Fsmvcost { get; set; }
        public double? Lsmvcost { get; set; }
    }
}
