using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmTaxationSetup
    {
        public decimal TaxId { get; set; }
        public string AccountName { get; set; }
        public string SectionNo { get; set; }
        public string NatureOfPayment { get; set; }
        public string TimeOfDeduction { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Concession { get; set; }
        public decimal CompanyId { get; set; }

        public virtual BasicCoa Tax { get; set; }
    }
}
