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

        // Foreign Keys
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
        public Department? Department { get; set; }

        [ForeignKey("DesignationID")]
        public Designation? Designation { get; set; }

        [ForeignKey("GradeID")]
        public SalaryGrade? SalaryGrade { get; set; }

        [ForeignKey("EmployeeCategoryID")]
        public EmployeeCategory? EmployeeCategory { get; set; }

        [ForeignKey("WorkScheduleID")]
        public WorkSchedule? WorkSchedule { get; set; }

        // Collections
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Leave>? Leaves { get; set; }
        public ICollection<Payroll>? Payrolls { get; set; }
        public ICollection<MedicalQualification>? MedicalQualifications { get; set; }
        public ICollection<OnCallSchedule>? OnCallSchedules { get; set; }
        public ICollection<WardAssignment>? WardAssignments { get; set; }
        public ICollection<SalaryStructure>? SalaryStructures { get; set; }
        public ICollection<EmployeeAllowance>? EmployeeAllowances { get; set; }
        public ICollection<EPFETFInfo>? EPFETFInfo { get; set; }
        public ICollection<EmployeePerformance>? PerformanceReviews { get; set; }
        public ICollection<Loan>? Loans { get; set; }
    }

}
