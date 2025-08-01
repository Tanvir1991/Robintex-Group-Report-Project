using Microsoft.EntityFrameworkCore;
using RTEXERP.DBEntities.Hrm;
using RTEXERP.DBEntities.Hrm.DbViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.DataContext
{
 
    public class HRTESTContext : DbContext
    {
        public HRTESTContext(DbContextOptions<HRTESTContext> options) : base(options) { }

        public virtual DbSet<Tbl_Emp> Tbl_Emp { get; set; }

        public virtual DbSet<Tbl_CHirarchy> Tbl_CHirarchy { get; set; }
        public virtual DbSet<ElectionMemberType> ElectionMemberType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Emp>(entity =>
            {
                entity.HasKey(e => e.EmpCd);
                             

                entity.HasIndex(e => new { e.EmpId, e.EmpCd, e.EmpCompany, e.EmpDept, e.EmpSection, e.EmpDesignation })
                    .HasName("Ind_Emp");

                entity.Property(e => e.EmpCd)
                    .HasColumnName("Emp_Cd")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AttendanceAllowance).HasDefaultValueSql("((0))");

                entity.Property(e => e.ConductAllowance).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeptCd)
                    .HasColumnName("Dept_Cd")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpAccount)
                    .HasColumnName("Emp_Account")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpAcode1)
                    .HasColumnName("Emp_Acode1")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpAcode2)
                    .HasColumnName("Emp_Acode2")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpAcode3)
                    .HasColumnName("Emp_Acode3")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpActive).HasColumnName("Emp_Active");

                entity.Property(e => e.EmpAddress1)
                    .HasColumnName("Emp_Address1")
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.EmpAddress2)
                    .HasColumnName("Emp_Address2")
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.EmpAppointment)
                    .HasColumnName("Emp_Appointment")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpApproved)
                    .HasColumnName("Emp_Approved")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpAttAllow).HasColumnName("Emp_AttAllow");

                entity.Property(e => e.EmpAttType)
                    .HasColumnName("Emp_AttType")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EmpBaddress)
                    .HasColumnName("Emp_baddress")
                    .HasMaxLength(4000);

                entity.Property(e => e.EmpBank).HasColumnName("Emp_Bank");

                entity.Property(e => e.EmpBankId).HasColumnName("Emp_BankID");

                entity.Property(e => e.EmpBlockDate)
                    .HasColumnName("Emp_BlockDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpBlockReason)
                    .HasColumnName("Emp_BlockReason")
                    .IsUnicode(false);

                entity.Property(e => e.EmpBlocked).HasColumnName("Emp_Blocked");

                entity.Property(e => e.EmpBname)
                    .HasColumnName("Emp_Bname")
                    .HasMaxLength(4000);

                entity.Property(e => e.EmpCashPayroll).HasColumnName("Emp_CashPayroll");

                entity.Property(e => e.EmpCitizen)
                    .HasColumnName("Emp_Citizen")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCity1)
                    .HasColumnName("Emp_City1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCity2)
                    .HasColumnName("Emp_City2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCmail)
                    .HasColumnName("Emp_CMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCompany).HasColumnName("Emp_Company");

                entity.Property(e => e.EmpConfirmation)
                    .HasColumnName("Emp_Confirmation")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpCountry1).HasColumnName("Emp_Country1");

                entity.Property(e => e.EmpCountry2).HasColumnName("Emp_Country2");

                entity.Property(e => e.EmpCreated)
                    .HasColumnName("Emp_Created")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EmpDeleted).HasColumnName("Emp_Deleted");

                entity.Property(e => e.EmpDept).HasColumnName("Emp_Dept");

                entity.Property(e => e.EmpDesignation).HasColumnName("Emp_Designation");

                entity.Property(e => e.EmpDob)
                    .HasColumnName("Emp_DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpDocType)
                    .HasColumnName("emp_docType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmail)
                    .HasColumnName("Emp_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEobiDeduction)
                    .HasColumnName("Emp_EOBI_Deduction")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpExt)
                    .HasColumnName("Emp_Ext")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFather)
                    .HasColumnName("Emp_Father")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFbname)
                    .HasColumnName("Emp_FBname")
                    .HasMaxLength(4000);

                entity.Property(e => e.EmpFingerPrintCd).HasColumnName("Emp_FingerPrintCD");

                entity.Property(e => e.EmpFname)
                    .HasColumnName("Emp_Fname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpGender)
                    .HasColumnName("Emp_Gender")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpGross).HasColumnName("Emp_Gross");

                entity.Property(e => e.EmpHalfdayallowed).HasColumnName("Emp_halfdayallowed");

                entity.Property(e => e.EmpId)
                    .HasColumnName("Emp_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmpIncOt).HasColumnName("Emp_IncOT");

                entity.Property(e => e.EmpIncentives)
                    .HasColumnName("Emp_Incentives")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmpInterviewNo)
                    .HasColumnName("Emp_InterviewNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpInterviewed)
                    .HasColumnName("Emp_Interviewed")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLastincamount).HasColumnName("Emp_lastincamount");

                entity.Property(e => e.EmpLastincrement)
                    .HasColumnName("Emp_lastincrement")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpLcountry).HasColumnName("Emp_LCountry");

                entity.Property(e => e.EmpLegacyCategory)
                    .HasColumnName("Emp_LegacyCategory")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EmpLegacyType).HasColumnName("Emp_LegacyType");

                entity.Property(e => e.EmpLexpiry)
                    .HasColumnName("Emp_LExpiry")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EmpLicense)
                    .HasColumnName("Emp_License")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLissue)
                    .HasColumnName("Emp_LIssue")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EmpLname)
                    .HasColumnName("Emp_Lname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpMarital).HasColumnName("Emp_Marital");

                entity.Property(e => e.EmpMbname)
                    .HasColumnName("Emp_MBname")
                    .HasMaxLength(4000);

                entity.Property(e => e.EmpMname)
                    .HasColumnName("Emp_Mname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpMobile)
                    .HasColumnName("Emp_Mobile")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpMotherName)
                    .HasColumnName("Emp_MotherName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasColumnName("Emp_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNicexp)
                    .HasColumnName("Emp_NICExp")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EmpOldNo)
                    .HasColumnName("Emp_oldNo")
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.EmpOldnoNumeric).HasColumnName("Emp_OldnoNumeric");

                entity.Property(e => e.EmpOt).HasColumnName("Emp_OT");

                entity.Property(e => e.EmpPayroll)
                    .HasColumnName("Emp_Payroll")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpPermanentlyBlocked).HasColumnName("Emp_PermanentlyBlocked");

                entity.Property(e => e.EmpPf)
                    .HasColumnName("Emp_PF")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmpPlaceofBirth)
                    .HasColumnName("Emp_PlaceofBirth")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpProximity)
                    .HasColumnName("Emp_Proximity")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpRace)
                    .HasColumnName("Emp_Race")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpReligion).HasColumnName("Emp_Religion");

                entity.Property(e => e.EmpRestDay)
                    .HasColumnName("Emp_RestDay")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.EmpRoute).HasColumnName("Emp_Route");

                entity.Property(e => e.EmpSalary)
                    .HasColumnName("Emp_Salary")
                    .HasComputedColumnSql("([Emp_Incentives]+[Emp_Gross])");

                entity.Property(e => e.EmpSalaryStructure)
                    .HasColumnName("Emp_SalaryStructure")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpSalutation)
                    .HasColumnName("Emp_Salutation")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmpSect)
                    .HasColumnName("Emp_Sect")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpSection).HasColumnName("Emp_Section");

                entity.Property(e => e.EmpShift).HasColumnName("Emp_Shift");

                entity.Property(e => e.EmpSsn)
                    .HasColumnName("Emp_SSN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpSsn2)
                    .HasColumnName("Emp_SSN2")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpSsnDeduction)
                    .HasColumnName("Emp_SSN_Deduction")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpState1)
                    .HasColumnName("Emp_State1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpState2)
                    .HasColumnName("Emp_State2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpTaddress)
                    .HasColumnName("Emp_taddress")
                    .HasMaxLength(4000);

                entity.Property(e => e.EmpTaxDed).HasColumnName("Emp_TaxDed");

                entity.Property(e => e.EmpTel1)
                    .HasColumnName("Emp_Tel1")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpTel2)
                    .HasColumnName("Emp_Tel2")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpTel3)
                    .HasColumnName("Emp_Tel3")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpType)
                    .HasColumnName("emp_type")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpUser)
                    .HasColumnName("Emp_User")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EmpZip1)
                    .HasColumnName("Emp_Zip1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpZip2)
                    .HasColumnName("Emp_Zip2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExtraAllowance).HasDefaultValueSql("((0))");

                entity.Property(e => e.FestivalAllowance).HasDefaultValueSql("((0))");

                entity.Property(e => e.HoliDayAllowance).HasDefaultValueSql("((0))");

                entity.Property(e => e.NighAllowance)
                    .HasColumnName("nighAllowance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SecCd)
                    .HasColumnName("Sec_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ElectionMemberType>(entity =>
            {
                entity.Property(e => e.TypeNameBN)
                  .IsUnicode(false);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
