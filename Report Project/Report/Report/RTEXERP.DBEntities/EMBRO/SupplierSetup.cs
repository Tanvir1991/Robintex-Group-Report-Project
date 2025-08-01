using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class SupplierSetup
    {
        public SupplierSetup()
        {
            ApmPaymentModesDetail = new HashSet<ApmPaymentModesDetail>();
            ApmSupplierPaymentTerms = new HashSet<ApmSupplierPaymentTerms>();
        }

        public decimal Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxRegNumber { get; set; }
        public string Ntnnumber { get; set; }
        public string Comments { get; set; }
        public string SupplierType { get; set; }

        public virtual ICollection<ApmPaymentModesDetail> ApmPaymentModesDetail { get; set; }
        public virtual ICollection<ApmSupplierPaymentTerms> ApmSupplierPaymentTerms { get; set; }
    }
}
