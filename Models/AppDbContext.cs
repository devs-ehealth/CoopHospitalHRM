using CoopHospitalHRM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Master Tables
        public DbSet<Department> Department { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategory { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<SalaryGrade> SalaryGrade { get; set; }
        public DbSet<WorkSchedule> WorkSchedule { get; set; }
        public DbSet<LeaveType> LeaveType { get; set; }
        public DbSet<HospitalAllowance> HospitalAllowance { get; set; }
        public DbSet<SystemRole> SystemRole { get; set; }

        // Core Tables
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<LeaveBalance> LeaveBalance { get; set; }
        public DbSet<SalaryStructure> SalaryStructure { get; set; }
        public DbSet<EmployeeAllowance> EmployeeAllowance { get; set; }
        public DbSet<Payroll> Payroll { get; set; }
        public DbSet<PayrollTransaction> PayrollTransaction { get; set; }

        // EPF/ETF Tables
        public DbSet<EPFETFInfo> EPFETFInfo { get; set; }
        public DbSet<EPFContribution> EPFContribution { get; set; }
        public DbSet<ETFContribution> ETFContribution { get; set; }

        // Hospital Specific Tables
        public DbSet<MedicalQualification> MedicalQualification { get; set; }
        public DbSet<OnCallSchedule> OnCallSchedule { get; set; }
        public DbSet<WardAssignment> WardAssignment { get; set; }

        // Additional Tables
        public DbSet<Loan> Loan { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<EmployeePerformance> EmployeePerformance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Master Tables mapping - FIXED TABLE NAMES
            modelBuilder.Entity<Department>().ToTable("HR_Departments"); // Was: HR_Department
            modelBuilder.Entity<EmployeeCategory>().ToTable("HR_EmployeeCategories"); // Was: HR_EmployeeCategory
            modelBuilder.Entity<Designation>().ToTable("HR_Designations"); // Was: HR_Designation
            modelBuilder.Entity<SalaryGrade>().ToTable("HR_SalaryGrades"); // Was: HR_SalaryGrade
            modelBuilder.Entity<WorkSchedule>().ToTable("HR_WorkSchedules"); // Was: HR_WorkSchedul
            modelBuilder.Entity<LeaveType>().ToTable("HR_LeaveTypes"); // Was: HR_LeaveType
            modelBuilder.Entity<HospitalAllowance>().ToTable("HR_HospitalAllowances"); // Was: HR_HospitalAllowance
            modelBuilder.Entity<SystemRole>().ToTable("HR_SystemRoles"); // Was: HR_SystemRole

            // Core Tables mapping - FIXED TABLE NAMES
            modelBuilder.Entity<Employee>().ToTable("HR_Employees"); // This is correct
            modelBuilder.Entity<Attendance>().ToTable("HR_Attendance"); // This is correct
            modelBuilder.Entity<Leave>().ToTable("HR_Leaves"); // Was: HR_Leave
            modelBuilder.Entity<LeaveBalance>().ToTable("HR_LeaveBalances"); // Was: HR_LeaveBalance
            modelBuilder.Entity<SalaryStructure>().ToTable("HR_SalaryStructures"); // Was: HR_SalaryStructure
            modelBuilder.Entity<EmployeeAllowance>().ToTable("HR_EmployeeAllowances"); // Was: HR_EmployeeAllowance
            modelBuilder.Entity<Payroll>().ToTable("HR_Payrolls"); // Was: HR_Payroll
            modelBuilder.Entity<PayrollTransaction>().ToTable("HR_PayrollTransactions"); // Was: HR_PayrollTransaction

            // EPF/ETF Tables mapping - FIXED TABLE NAMES
            modelBuilder.Entity<EPFETFInfo>().ToTable("HR_EPFETFInfo"); // This is correct
            modelBuilder.Entity<EPFContribution>().ToTable("HR_EPFContributions"); // Was: HR_EPFContribution
            modelBuilder.Entity<ETFContribution>().ToTable("HR_ETFContributions"); // Was: HR_ETFContribution

            // Hospital Specific Tables mapping - FIXED TABLE NAMES
            modelBuilder.Entity<MedicalQualification>().ToTable("HR_MedicalQualifications"); // Was: HR_MedicalQualification
            modelBuilder.Entity<OnCallSchedule>().ToTable("HR_OnCallSchedule"); // This is correct
            modelBuilder.Entity<WardAssignment>().ToTable("HR_WardAssignments"); // Was: HR_WardAssignment

            // Additional Tables mapping - FIXED TABLE NAMES
            modelBuilder.Entity<Loan>().ToTable("HR_Loans"); // Was: HR_Loan
            modelBuilder.Entity<SystemUser>().ToTable("HR_SystemUsers"); // Was: HR_SystemUser
            modelBuilder.Entity<EmployeePerformance>().ToTable("HR_EmployeePerformance"); // This is correct

            // =============================================
            // RELATIONSHIP CONFIGURATIONS
            // =============================================

            // Employee - Department relationship (Many to One)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - Designation relationship (Many to One)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Designation)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DesignationID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - EmployeeCategory relationship (Many to One)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.EmployeeCategory)
                .WithMany(ec => ec.Employees)
                .HasForeignKey(e => e.EmployeeCategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - SalaryGrade relationship (Many to One)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.SalaryGrade)
                .WithMany(sg => sg.Employees)
                .HasForeignKey(e => e.GradeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - WorkSchedule relationship (Many to One)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.WorkSchedule)
                .WithMany(ws => ws.Employees)
                .HasForeignKey(e => e.WorkScheduleID)
                .OnDelete(DeleteBehavior.Restrict);

            // =============================================
            // EMPLOYEE COLLECTIONS CONFIGURATION
            // =============================================

            // Employee - Attendances (One to Many)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - Leaves (One to Many)
            modelBuilder.Entity<Leave>()
                .HasOne(l => l.Employee)
                .WithMany(e => e.Leaves)
                .HasForeignKey(l => l.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - Payrolls (One to Many)
            modelBuilder.Entity<Payroll>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - MedicalQualifications (One to Many)
            modelBuilder.Entity<MedicalQualification>()
                .HasOne(mq => mq.Employee)
                .WithMany(e => e.MedicalQualifications)
                .HasForeignKey(mq => mq.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - OnCallSchedules (One to Many)
            modelBuilder.Entity<OnCallSchedule>()
                .HasOne(ocs => ocs.Employee)
                .WithMany(e => e.OnCallSchedules)
                .HasForeignKey(ocs => ocs.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - WardAssignments (One to Many)
            modelBuilder.Entity<WardAssignment>()
                .HasOne(wa => wa.Employee)
                .WithMany(e => e.WardAssignments)
                .HasForeignKey(wa => wa.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - SalaryStructures (One to Many)
            modelBuilder.Entity<SalaryStructure>()
                .HasOne(ss => ss.Employee)
                .WithMany(e => e.SalaryStructures)
                .HasForeignKey(ss => ss.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - EmployeeAllowances (One to Many)
            modelBuilder.Entity<EmployeeAllowance>()
                .HasOne(ea => ea.Employee)
                .WithMany(e => e.EmployeeAllowances)
                .HasForeignKey(ea => ea.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - EPFETFInfo (One to Many)
            modelBuilder.Entity<EPFETFInfo>()
                .HasOne(epf => epf.Employee)
                .WithMany(e => e.EPFETFInfo)
                .HasForeignKey(epf => epf.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - Loans (One to Many)
            modelBuilder.Entity<Loan>()
                .HasOne(ln => ln.Employee)
                .WithMany(e => e.Loans)
                .HasForeignKey(ln => ln.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee Performance - Self Referencing for Reviewer
            modelBuilder.Entity<EmployeePerformance>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.PerformanceReviews)
                .HasForeignKey(ep => ep.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeePerformance>()
                .HasOne(ep => ep.Reviewer)
                .WithMany(e => e.GivenReviews)
                .HasForeignKey(ep => ep.ReviewerID)
                .OnDelete(DeleteBehavior.Restrict);

            // =============================================
            // APPROVER RELATIONSHIPS - FIXED
            // =============================================

            // Attendance - Approver relationship
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Approver)
                .WithMany()
                .HasForeignKey(a => a.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Leave - Approver relationship
            modelBuilder.Entity<Leave>()
                .HasOne(l => l.Approver)
                .WithMany()
                .HasForeignKey(l => l.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // =============================================
            // UNIQUE CONSTRAINTS
            // =============================================

            // Employee unique constraints
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeCode)
                .IsUnique()
                .HasFilter("[EmployeeCode] IS NOT NULL");

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.NIC)
                .IsUnique()
                .HasFilter("[NIC] IS NOT NULL");

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique()
                .HasFilter("[Email] IS NOT NULL");

            // Leave balance unique constraint
            modelBuilder.Entity<LeaveBalance>()
                .HasIndex(lb => new { lb.EmployeeID, lb.LeaveTypeID, lb.Year })
                .IsUnique();

            // =============================================
            // DEFAULT VALUES & PROPERTY CONFIGURATIONS
            // =============================================

            // Default values
            modelBuilder.Entity<Employee>()
                .Property(e => e.Status)
                .HasDefaultValue("Active");

            modelBuilder.Entity<Attendance>()
                .Property(a => a.Status)
                .HasDefaultValue("Present");

            modelBuilder.Entity<Leave>()
                .Property(l => l.Status)
                .HasDefaultValue("Pending");

            // Decimal precision configurations
            modelBuilder.Entity<SalaryGrade>()
                .Property(sg => sg.BasicSalary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<SalaryStructure>()
                .Property(ss => ss.BasicSalary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payroll>()
                .Property(p => p.BasicSalary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<HospitalAllowance>()
                .Property(ha => ha.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<EmployeeAllowance>()
                .Property(ea => ea.Amount)
                .HasPrecision(18, 2);

            // String length configurations
            modelBuilder.Entity<Employee>()
                .Property(e => e.FullName)
                .HasMaxLength(200);

            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Designation>()
                .Property(d => d.DesignationName)
                .HasMaxLength(100)
                .IsRequired();

            // =============================================
            // ADDITIONAL RELATIONSHIPS
            // =============================================

            // EmployeeAllowance - HospitalAllowance relationship
            modelBuilder.Entity<EmployeeAllowance>()
                .HasOne(ea => ea.HospitalAllowance)
                .WithMany(ha => ha.EmployeeAllowances)
                .HasForeignKey(ea => ea.AllowanceID)
                .OnDelete(DeleteBehavior.Restrict);

            // SystemUser - Employee relationship
            modelBuilder.Entity<SystemUser>()
                .HasOne(su => su.Employee)
                .WithMany()
                .HasForeignKey(su => su.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // SystemUser - SystemRole relationship
            modelBuilder.Entity<SystemUser>()
                .HasOne(su => su.SystemRole)
                .WithMany(sr => sr.SystemUsers)
                .HasForeignKey(su => su.RoleID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}