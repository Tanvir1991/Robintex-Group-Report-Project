using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class LettersGenerated
    {
        public int LetterGeneratedId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? DateGenerated { get; set; }
        public int? BankId { get; set; }
        public int? AccountId { get; set; }
        public string BankRepresentative { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }
        public int? LetterType { get; set; }
        public int? FromBankId { get; set; }
        public int? FromAccountId { get; set; }
        public string FromAccountNo { get; set; }
        public int? ToBankId { get; set; }
        public decimal? ToAccountId { get; set; }
        public string ToAccountNo { get; set; }
        public string ToAccountTitle { get; set; }
        public string ToAccountAddress { get; set; }
        public double? Amount { get; set; }
        public string Cheqno { get; set; }
        public string CheqDate { get; set; }
        public string Favouring { get; set; }
        public int? Status { get; set; }
        public string Refno { get; set; }
    }
}
