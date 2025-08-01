using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Hrm
{

    public partial class Tbl_Emp
    {
        [Key]
        public long EmpId { get; set; }
        public string EmpCd { get; set; }
        public int? EmpCompany { get; set; }
        public int? EmpDept { get; set; }
        public int? EmpSection { get; set; }
        public int? EmpDesignation { get; set; }
        public int? EmpShift { get; set; }
        public DateTime? EmpAppointment { get; set; }
        public DateTime? EmpConfirmation { get; set; }
        public DateTime? EmpLastincrement { get; set; }
        public double? EmpLastincamount { get; set; }
        public string EmpSalutation { get; set; }
        public string EmpFname { get; set; }
        public string EmpMname { get; set; }
        public string EmpLname { get; set; }
        public string EmpFather { get; set; }
        public string EmpSsn { get; set; }
        public string EmpCitizen { get; set; }
        public short? EmpMarital { get; set; }
        public string EmpGender { get; set; }
        public DateTime? EmpDob { get; set; }
        public string EmpPlaceofBirth { get; set; }
        public string EmpAddress1 { get; set; }
        public string EmpCity1 { get; set; }
        public string EmpState1 { get; set; }
        public string EmpZip1 { get; set; }
        public short? EmpCountry1 { get; set; }
        public string EmpAddress2 { get; set; }
        public string EmpCity2 { get; set; }
        public string EmpState2 { get; set; }
        public string EmpZip2 { get; set; }
        public short? EmpCountry2 { get; set; }
        public string EmpAcode1 { get; set; }
        public string EmpTel1 { get; set; }
        public string EmpAcode2 { get; set; }
        public string EmpTel2 { get; set; }
        public string EmpAcode3 { get; set; }
        public string EmpTel3 { get; set; }
        public string EmpMobile { get; set; }
        public string EmpEmail { get; set; }
        public DateTime? EmpCreated { get; set; }
        public bool? EmpActive { get; set; }
        public DateTime? EmpBlockDate { get; set; }
        public short? EmpReligion { get; set; }
        public string EmpSect { get; set; }
        public string EmpRace { get; set; }
        public double? EmpGross { get; set; }
        public double? EmpIncentives { get; set; }
        public double? EmpSalary { get; set; }
        public bool? EmpDeleted { get; set; }
        public string DeptCd { get; set; }
        public string SecCd { get; set; }
        public bool? EmpOt { get; set; }
        public int? AttendanceAllowance { get; set; }
        public int? ConductAllowance { get; set; }
        public int? HoliDayAllowance { get; set; }
        public int? ExtraAllowance { get; set; }
        public int? NighAllowance { get; set; }
        public int? FestivalAllowance { get; set; }
        public double? TaxDeduction { get; set; }
        public int? EmpBank { get; set; }
        public bool? EmpAttAllow { get; set; }
        public bool? EmpTaxDed { get; set; }
        public bool? EmpBlocked { get; set; }
        public bool? EmpIncOt { get; set; }
        public string EmpAccount { get; set; }
        public int? EmpBankId { get; set; }
        public string EmpName { get; set; }
        public string EmpLicense { get; set; }
        public int? EmpLcountry { get; set; }
        public DateTime? EmpLissue { get; set; }
        public DateTime? EmpLexpiry { get; set; }
        public string EmpExt { get; set; }
        public string EmpCmail { get; set; }
        public bool? EmpPayroll { get; set; }
        public int? EmpType { get; set; }
        public string EmpInterviewed { get; set; }
        public string EmpApproved { get; set; }
        public string EmpOldNo { get; set; }
        public int? EmpOldnoNumeric { get; set; }
        public string EmpUser { get; set; }
        public string EmpSsn2 { get; set; }
        public string EmpSsnDeduction { get; set; }
        public string EmpEobiDeduction { get; set; }
        public string EmpProximity { get; set; }
        public bool? EmpCashPayroll { get; set; }
        public long? EmpRoute { get; set; }
        public DateTime? EmpNicexp { get; set; }
        public string EmpAttType { get; set; }
        public string EmpDocType { get; set; }
        public string EmpRestDay { get; set; }
        public bool? EmpPermanentlyBlocked { get; set; }
        public string EmpBlockReason { get; set; }
        public bool? EmpHalfdayallowed { get; set; }
        public string EmpLegacyCategory { get; set; }
        public int? EmpLegacyType { get; set; }
        public string EmpMotherName { get; set; }
        public int? EmpSalaryStructure { get; set; }
        public string EmpInterviewNo { get; set; }
        public bool? EmpPf { get; set; }
        public long? EmpFingerPrintCd { get; set; }
        public string EmpBname { get; set; }
        public string EmpFbname { get; set; }
        public string EmpMbname { get; set; }
        public string EmpTaddress { get; set; }
        public string EmpBaddress { get; set; }
    }
}
