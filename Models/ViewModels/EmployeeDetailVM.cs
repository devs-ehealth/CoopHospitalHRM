using CoopHospitalHRM.Models.ViewModels;

namespace CoopHospitalHRM.Models.ViewModels
{
    public class EmployeeDetailVM
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? InitialName { get; set; }
        public string NIC { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Address { get; set; }
        public DateTime? JoinDate { get; set; }

        // Navigation properties for display
        public string? DepartmentName { get; set; }
        public string? DesignationName { get; set; }
        public string? EmployeeCategoryName { get; set; }
        public string? WorkScheduleName { get; set; }
        public string? GradeName { get; set; }

        // Hospital Specific
        public string? MedicalLicenseNo { get; set; }
        public string? Specialization { get; set; }
        public int? YearsOfExperience { get; set; }
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
        public string? BloodGroup { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string Status { get; set; } = "Active";

        // Calculated properties
        public int? Age { get; set; }
        public int? YearsOfService { get; set; }

        // Additional details for profile view
        public List<MedicalQualificationVM>? Qualifications { get; set; }
        public List<LeaveBalanceVM>? LeaveBalances { get; set; }
        public AttendanceSummaryVM? AttendanceSummary { get; set; }
    }
}
