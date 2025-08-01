using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class Greige_StockTransactions
    {

        public long StockTransactionID { get; set; }
        public int DocumentNo { get; set; }
        public long? AttributeInstanceID { get; set; }
        public int ProgramTypeID { get; set; }
        public int? OrderID { get; set; }
        public int? StyleID { get; set; }
        public int DocumentTypeID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int SKUUnit { get; set; }
        public double Rate_WRTBaseUnit { get; set; }
        public double Quantity { get; set; }
        public int? NoOfRolls { get; set; }
        public int? NoOfPieces { get; set; }
        public int Status { get; set; }
        public int? YKNCID { get; set; }
        public int? RollID { get; set; }
        public int? QualityID { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public int? StoreLocationID { get; set; }
        public string RollNo { get; set; }
        public int? MachineID { get; set; }
        public string Comments { get; set; }
        public int? rollnonew { get; set; }
        public string rollnop { get; set; }
    }
}
