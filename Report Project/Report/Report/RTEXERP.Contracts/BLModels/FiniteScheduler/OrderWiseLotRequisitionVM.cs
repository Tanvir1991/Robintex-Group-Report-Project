namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class OrderWiseLotRequisitionVM
    {
        public int OrderID { get; set; }
        public long LotID { get; set; }
        public long IRID { get; set; }
        public long IRCode { get; set; }
        public string Req_TypeName { get; set; }
        public string OrderNo { get; set; }
        public string LotNo { get; set; }
        public decimal GreigeQuantity { get; set; }
        public decimal FinishQuantity { get; set; }
    }

}
