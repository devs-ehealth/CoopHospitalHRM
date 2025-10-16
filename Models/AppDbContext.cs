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
        public DbSet<CoopHospitalHRM.Models.Entities.Department> Department { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.EmployeeCategory> EmployeeCategory { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.Designation> Designation { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.SalaryGrade> SalaryGrade { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.WorkSchedule> WorkSchedule { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.LeaveType> LeaveType { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.HospitalAllowance> HospitalAllowance { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.SystemRole> SystemRole { get; set; }

        // Core Tables
        public DbSet<CoopHospitalHRM.Models.Entities.Employee> Employee { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.Attendance> Attendance { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.Leave> Leave { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.LeaveBalance> LeaveBalance { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.SalaryStructure> SalaryStructure { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.EmployeeAllowance> EmployeeAllowance { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.Payroll> Payroll { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.PayrollTransaction> PayrollTransaction { get; set; }

        // EPF/ETF Tables
        public DbSet<CoopHospitalHRM.Models.Entities.EPFETFInfo> EPFETFInfo { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.EPFContribution> EPFContribution { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.ETFContribution> ETFContribution { get; set; }

        // Hospital Specific Tables
        public DbSet<CoopHospitalHRM.Models.Entities.MedicalQualification> MedicalQualification { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.OnCallSchedule> OnCallSchedule { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.WardAssignment> WardAssignment { get; set; }

        // Additional Tables
        public DbSet<CoopHospitalHRM.Models.Entities.Loan> Loan { get; set; }
        public DbSet<CoopHospitalHRM.Models.Entities.SystemUser> SystemUser { get; set; }
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
                .HasOne(a => a.Employee)
    .WithMany()
    .HasForeignKey(a => a.EmployeeID)
    .OnDelete(DeleteBehavior.Restrict);

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
                .HasOne(a => a.Employee)
    .WithMany()
    .HasForeignKey(a => a.EmployeeID)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CoopHospitalHRM.Models.Entities.Loan>()
                .HasOne(a => a.Employee)
    .WithMany()
    .HasForeignKey(a => a.EmployeeID)
    .OnDelete(DeleteBehavior.Restrict);

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