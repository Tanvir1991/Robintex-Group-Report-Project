using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class CountryInformation
    {
        public long Id { get; set; }
        public int? Cid { get; set; }
        public int? Bid { get; set; }
        public string ShortName { get; set; }
        public string BuyerName { get; set; }
        public string BuyerAddress { get; set; }
        public string Consignee { get; set; }
        public string DeliveryTerms { get; set; }
        public string DistPort { get; set; }
        public string ConsigneeBank { get; set; }
        public string LoadingPort { get; set; }
        public string DischargePort { get; set; }
        public string DeliveryPort { get; set; }
        public string ShippingMark { get; set; }
        public string Deliveryto { get; set; }
    }
}
