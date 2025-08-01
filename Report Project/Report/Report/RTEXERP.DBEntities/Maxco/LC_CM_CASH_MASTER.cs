using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public partial class LC_CM_CASH_MASTER
    {
        [Key]
        public long LCM_ID { get; set; }
        public string LCM_CODE { get; set; }
        public int? LCM_MODUSERID { get; set; }
        public DateTime? LCM_LASTMODDATE { get; set; }
        public long? LCM_ITEMID { get; set; }
        public long LCM_VENDOR_ID { get; set; }
        public long? LCM_COMPANY_ID { get; set; }
        public long? LCM_COMPANYBANK_ID { get; set; }
        public long? LCM_BANKACCOUNTID { get; set; }
        public int LCM_ISSUANCECITYID { get; set; }
        public DateTime LCM_DATEOFISSUANCE { get; set; }
        public int LCM_EXPIRYCITYID { get; set; }
        public DateTime LCM_DATEOFEXPIRY { get; set; }
        public int LCM_LCCONDITION { get; set; }
        public string LCM_LCANO { get; set; }
        public string LCM_IRCNO { get; set; }
        public string LCM_INSSURANCECOM { get; set; }
        public string LCM_INSSURANCECOMADD { get; set; }
        public string LCM_INSSURANCECOMNOTENO { get; set; }
        public string LCM_HSCODE { get; set; }
        public int? HSODE_ID { get; set; }
        public string LCM_PORTOFSHIPMENT { get; set; }
        public DateTime? LCM_DATEOFSHIPMENT { get; set; }
        public string LCM_PORTOFDISSCHARGE { get; set; }
        public string LCM_MODOFSHIPMENT { get; set; }
        public DateTime LCM_CREATIONDATE { get; set; }
        public long LCM_CREATIONUSERID { get; set; }
        public string LCM_SPECIALCOMMENTS { get; set; }
        public string LCM_BANKNO { get; set; }
        public int? LCM_MAPSTATUS { get; set; }
        public string LCM_CONTRY_ORIGIN { get; set; }
        public decimal LCM_PIValue { get; set; }
        public long? LOM_ID { get; set; }
        public int? Currency { get; set; }
        public string LCM_HEADER { get; set; }
        public string LCM_FOOTER { get; set; }
        public string LCM_CONDITIONS { get; set; }
        public string LCM_PAYMENT_TERMS { get; set; }
        public string LCM_INTEREST { get; set; }
        public DateTime? LCM_BankLCDate { get; set; }
    }
}
