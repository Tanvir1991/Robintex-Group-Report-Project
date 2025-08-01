using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblPayrollMaster
    {
        public long PayrollId { get; set; }
        public long? PayrollEmp { get; set; }
        public string PayrollEmpCd { get; set; }
        public DateTime PayrollFrom { get; set; }
        public DateTime PayrollTo { get; set; }
        public int? PayrollMonth { get; set; }
        public int? PayrollYear { get; set; }
        public int? PayrollVersion { get; set; }
        public bool? PayrollModified { get; set; }
        public int? PayrollStatus { get; set; }
        public bool? PayrollPaid { get; set; }
        public DateTime? PayrollPaidDate { get; set; }
        public bool? PayrollBank { get; set; }
        public double? PayrollBasic { get; set; }
        public double? PayrollAllowance { get; set; }
        public double? PayrollTaxable { get; set; }
        public short? PayrollEmpTotalDays { get; set; }
        public double? PayrollPresent { get; set; }
        public short? PayrollAbsent { get; set; }
        public short? PayrollOffDay { get; set; }
        public short? PayrollLwp { get; set; }
        public short? PayrollLwop { get; set; }
        public short? PayrollHoliday { get; set; }
        public double? PayrollPayDays { get; set; }
        public short? PayrollTtldays { get; set; }
        public short? PayrollDefault { get; set; }
        public double? PayrollWorkedHours { get; set; }
        public double? PayrollWorkedHoursAmount { get; set; }
        public double? PayrollOtHrs { get; set; }
        public double? PayrollOtAmt { get; set; }
        public double? PayrollExtraOtHrs { get; set; }
        public double? PayrollExtraOtAmt { get; set; }
        public double? PayrollAttendanceAllownce { get; set; }
        public double? PayrollConductAllowance { get; set; }
        public double? PayrollProductionBonus { get; set; }
        public double? PayrollTotalAllowances { get; set; }
        public double? PayrollOtherAllowances { get; set; }
        public double? PayrollGrossSalary { get; set; }
        public double? PayrollStampDeduction { get; set; }
        public double? PayrollDeduction { get; set; }
        public double? PayrollAdvance { get; set; }
        public double? PayrollLoan { get; set; }
        public double? PayrollStampDeductions { get; set; }
        public double? PayrollWelfareFund { get; set; }
        public double? PayrollTax { get; set; }
        public double? PayrollNetSalary { get; set; }
        public double? PayrollBasicSalary { get; set; }
        public double? PayrollBasicSalaryEarned { get; set; }
        public double? PayrollHouseRent { get; set; }
        public double? PayrollHouseRentEarned { get; set; }
        public double? PayrollMedical { get; set; }
        public double? PayrollMedicalEarned { get; set; }
        public double? PayrollConveyance { get; set; }
        public double? PayrollConveyanceEarned { get; set; }
        public short? PayrollRoundOff { get; set; }
        public short? PayrollCompany { get; set; }
        public short? PayrollDivision { get; set; }
        public short? PayrollDept { get; set; }
        public short? PayrollSection { get; set; }
        public short? PayrollDesignation { get; set; }
        public int? PayrollPfvalue { get; set; }
        public int? PayrollEmpCategory { get; set; }
        public long? PayrollCompanyId { get; set; }
        public int? InvoiceEffect { get; set; }
    }
}
