using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Master Tables
        public DbSet<CoopHospitalHRM.Models.Entities.Department> Departments { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.EmployeeCategory> EmployeeCategories { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.Designation> Designations { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.SalaryGrade> SalaryGrades { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.WorkSchedule> WorkSchedules { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.LeaveType> LeaveTypes { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.HospitalAllowance> HospitalAllowances { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.SystemRole> SystemRoles { get; set; }

        // Core Tables
        public DbSet<CoopHospitalHRM.Models.Entities.Employee> Employees { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.Attendance> Attendance { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.Leave> Leaves { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.LeaveBalance> LeaveBalances { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.SalaryStructure> SalaryStructures { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.EmployeeAllowance> EmployeeAllowances { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.Payroll> Payrolls { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.PayrollTransaction> PayrollTransactions { get; set; }

        // EPF/ETF Tables
        public DbSet<CoopHospitalHRM.Models.Entities.EPFETFInfo> EPFETFInfo { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.EPFContribution> EPFContributions { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.ETFContribution> ETFContributions { get; set; }

        // Hospital Specific Tables
        public DbSet<CoopHospitalHRM.Models.Entities.MedicalQualification> MedicalQualifications { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.OnCallSchedule> OnCallSchedules { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.WardAssignment> WardAssignments { get; set; }

        // Additional Tables
        public DbSet<CoopHospitalHRM.Models.Entities.Loan> Loans { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.SystemUser> SystemUsers { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.EmployeePerformance> EmployeePerformance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints

            // Employee - Department relationship
            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - Designation relationship
            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Employee>()
                .HasOne(e => e.Designation)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DesignationID)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique constraints
            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Employee>()
                .HasIndex(e => e.EmployeeCode)
                .IsUnique()
                .HasFilter("[EmployeeCode] IS NOT NULL");

            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Employee>()
                .HasIndex(e => e.NIC)
                .IsUnique()
                .HasFilter("[NIC] IS NOT NULL");

            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Employee>()
                .HasIndex(e => e.Email)
                .IsUnique()
                .HasFilter("[Email] IS NOT NULL");

            // Attendance unique constraint for employee and date
            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Attendance>()
                .HasIndex(a => new { a.EmployeeID, a.Date })
                .IsUnique()
                .HasFilter("[Date] IS NOT NULL");

            // Leave balance unique constraint
            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.LeaveBalance>()
                .HasIndex(lb => new { lb.EmployeeID, lb.LeaveTypeID, lb.Year })
                .IsUnique();

            // Set default values
            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Employee>()
                .Property(e => e.Status)
                .HasDefaultValue("Active");

            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Attendance>()
                .Property(a => a.Status)
                .HasDefaultValue("Present");

            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Leave>()
                .Property(l => l.Status)
                .HasDefaultValue("Pending");

            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Loan>()
                .Property(l => l.Status)
                .HasDefaultValue("Active");

            // Configure decimal precision
            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.SalaryGrade>()
                .Property(sg => sg.BasicSalary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.SalaryStructure>()
                .Property(ss => ss.BasicSalary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Payroll>()
                .Property(p => p.BasicSalary)
                .HasPrecision(18, 2);

            // Configure string lengths
            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Employee>()
                .Property(e => e.FullName)
                .HasMaxLength(200);

            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Department>()
                .Property(d => d.DepartmentName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}