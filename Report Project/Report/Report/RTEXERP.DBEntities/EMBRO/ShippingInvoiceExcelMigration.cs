using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ShippingInvoiceExcelMigration
    {
        public int Id { get; set; }
        public int? ExcelSerial { get; set; }
        public string InvoiceNo { get; set; }
        public string ShippingBillNo { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime ExcelUploadDate { get; set; }
        public bool IsMigrated { get; set; }
        public DateTime? MigrationDate { get; set; }
        public string MigrationIdList { get; set; }
        public bool IsRemoved { get; set; }
        public string ModifiedDescription { get; set; }
    }
}
