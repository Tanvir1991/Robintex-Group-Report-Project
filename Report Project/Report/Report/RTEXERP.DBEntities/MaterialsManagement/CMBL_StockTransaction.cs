using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_StockTransaction
    {
        [Key]
        public long StockTransactionID { get; set; }
        public int DocumentTypeID { get; set; }
        public int DocumentNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public long ItemID { get; set; }
       
        public double Quantity { get; set; }
        public int UserSelectedUnit { get; set; }
        public double Rate_WRTbaseUnit { get; set; }
        public int StoreLocationID { get; set; }
        public int Status { get; set; }
        public int Deleted { get; set; }
        public long CompanyID { get; set; }
        public long? IRRID { get; set; }
        public string Comments { get; set; }
        public long? ModelID { get; set; }
        public long? Misc { get; set; }
        public long? YarnKNContractID { get; set; }
        public long? OrderID { get; set; }
        public long? StyleID { get; set; }
        public long? aop_ReqDID { get; set; }

    }
}
