using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class OrderShipment
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? Poid { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int? TermsOfPayment { get; set; }
        public int? AgencyId { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public bool? IsByAir { get; set; }
        public string Comments { get; set; }
        public string Warehouse { get; set; }
        public string Address { get; set; }
        public string DeliveryTo { get; set; }
        public string Consignee { get; set; }
        public string ShortName { get; set; }
        public string TeriffCode { get; set; }
        public string Catagory { get; set; }
        public string Description { get; set; }
        public string ConsigneeBank { get; set; }
        public string DeliveryTerm { get; set; }
        public string LoadingPort { get; set; }
        public string DeliveryPort { get; set; }
        public string ShippingMark { get; set; }
    }
}
