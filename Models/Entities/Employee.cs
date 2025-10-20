using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [StringLength(20)]
        public string? EmployeeCode { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? InitialName { get; set; }

        [StringLength(20)]
        public string? NIC { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        public DateTime? JoinDate { get; set; }

        // Foreign Keys - Make sure these match your database
        public int? DepartmentID { get; set; }
        public int? DesignationID { get; set; }
        public int? GradeID { get; set; }
        public int? EmployeeCategoryID { get; set; }
        public int? WorkScheduleID { get; set; }

        // Hospital Specific Fields
        [StringLength(100)]
        public string? MedicalLicenseNo { get; set; }

        [StringLength(200)]
        public string? Specialization { get; set; }

        public int? YearsOfExperience { get; set; }

        [StringLength(100)]
        public string? EmergencyContact { get; set; }

        [StringLength(20)]
        public string? EmergencyPhone { get; set; }

        [StringLength(5)]
        public string? BloodGroup { get; set; }

        [StringLength(50)]
        public string? BankAccountNumber { get; set; }

        [StringLength(100)]
        public string? BankName { get; set; }

        [StringLength(100)]
        public string? BranchName { get; set; }

        [StringLength(20)]
        public string? Status { get; set; } = "Active";

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        [ForeignKey("DepartmentID")]
        public virtual Department? Department { get; set; }

        [ForeignKey("DesignationID")]
        public virtual Designation? Designation { get; set; }

        [ForeignKey("GradeID")]
        public virtual SalaryGrade? SalaryGrade { get; set; }

        [ForeignKey("EmployeeCategoryID")]
        public virtual EmployeeCategory? EmployeeCategory { get; set; }

        [ForeignKey("WorkScheduleID")]
        public virtual WorkSchedule? WorkSchedule { get; set; }

        // Collections - make virtual for lazy loading
        public virtual ICollection<Attendance>? Attendances { get; set; }
        public virtual ICollection<Leave>? Leaves { get; set; }
        public virtual ICollection<Payroll>? Payrolls { get; set; }
        public virtual ICollection<MedicalQualification>? MedicalQualifications { get; set; }
        public virtual ICollection<OnCallSchedule>? OnCallSchedules { get; set; }
        public virtual ICollection<WardAssignment>? WardAssignments { get; set; }
        public virtual ICollection<SalaryStructure>? SalaryStructures { get; set; }
        public virtual ICollection<EmployeeAllowance>? EmployeeAllowances { get; set; }
        public virtual ICollection<EPFETFInfo>? EPFETFInfo { get; set; }
        public virtual ICollection<EmployeePerformance>? PerformanceReviews { get; set; }
        public virtual ICollection<EmployeePerformance>? GivenReviews { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }
    }
}