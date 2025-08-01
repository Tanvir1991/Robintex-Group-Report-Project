using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.dbo
{
    public partial class ApplicationSetting
    {
        public int ApplicationSettingId { get; set; }
        public int? CompanyId { get; set; }
        public string OrganizationName { get; set; }
        public DateTime? MonthClosingDate { get; set; }
        public DateTime? YearClosingDate { get; set; }
        public string CashBook { get; set; }
        public string Placcount { get; set; }
        public string BankAccount { get; set; }
        public string LicenseNo { get; set; }
        public DateTime? LicenseStartDate { get; set; }
        public DateTime? LicenseEndDate { get; set; }
        public bool IsRemoved { get; set; }
        public long CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public long? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
