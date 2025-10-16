using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HospitalHRM.Models.ViewModels
{
    public class EmployeeVM
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Code is required")]
        [Display(Name = "Employee Code")]
        [StringLength(20, ErrorMessage = "Employee Code cannot exceed 20 characters")]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        [StringLength(200, ErrorMessage = "Full Name cannot exceed 200 characters")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Name with Initials")]
        [StringLength(100, ErrorMessage = "Initial Name cannot exceed 100 characters")]
        public string? InitialName { get; set; }

        [Required(ErrorMessage = "NIC is required")]
        [Display(Name = "NIC Number")]
        [StringLength(20, ErrorMessage = "NIC cannot exceed 20 characters")]
        [RegularExpression(@"^([0-9]{9}[x|X|v|V]|[0-9]{12})$", ErrorMessage = "Invalid NIC format")]
        public string NIC { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Address")]
        [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Join Date is required")]
        [Display(Name = "Join Date")]
        [DataType(DataType.Date)]
        public DateTime? JoinDate { get; set; }

        // Foreign Key Properties
        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [Display(Name = "Designation")]
        public int? DesignationID { get; set; }

        [Display(Name = "Salary Grade")]
        public int? GradeID { get; set; }

        [Required(ErrorMessage = "Employee Category is required")]
        [Display(Name = "Employee Category")]
        public int? EmployeeCategoryID { get; set; }

        [Display(Name = "Work Schedule")]
        public int? WorkScheduleID { get; set; }

        // Hospital Specific Fields
        [Display(Name = "Medical License No")]
        [StringLength(100, ErrorMessage = "Medical License No cannot exceed 100 characters")]
        public string? MedicalLicenseNo { get; set; }

        [Display(Name = "Specialization")]
        [StringLength(200, ErrorMessage = "Specialization cannot exceed 200 characters")]
        public string? Specialization { get; set; }

        [Display(Name = "Years of Experience")]
        [Range(0, 50, ErrorMessage = "Years of experience must be between 0 and 50")]
        public int? YearsOfExperience { get; set; }

        [Display(Name = "Emergency Contact Person")]
        [StringLength(100, ErrorMessage = "Emergency contact name cannot exceed 100 characters")]
        public string? EmergencyContact { get; set; }

        [Display(Name = "Emergency Contact Phone")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20, ErrorMessage = "Emergency phone cannot exceed 20 characters")]
        public string? EmergencyPhone { get; set; }

        [Display(Name = "Blood Group")]
        [StringLength(5, ErrorMessage = "Blood group cannot exceed 5 characters")]
        public string? BloodGroup { get; set; }

        // Bank Details
        [Display(Name = "Bank Account Number")]
        [StringLength(50, ErrorMessage = "Account number cannot exceed 50 characters")]
        public string? BankAccountNumber { get; set; }

        [Display(Name = "Bank Name")]
        [StringLength(100, ErrorMessage = "Bank name cannot exceed 100 characters")]
        public string? BankName { get; set; }

        [Display(Name = "Branch Name")]
        [StringLength(100, ErrorMessage = "Branch name cannot exceed 100 characters")]
        public string? BranchName { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Active";

        // Calculated Properties (Read-only for display)
        [Display(Name = "Age")]
        public int? Age
        {
            get
            {
                if (DOB.HasValue)
                {
                    var today = DateTime.Today;
                    var age = today.Year - DOB.Value.Year;
                    if (DOB.Value.Date > today.AddYears(-age)) age--;
                    return age;
                }
                return null;
            }
        }

        [Display(Name = "Years of Service")]
        public int? YearsOfService
        {
            get
            {
                if (JoinDate.HasValue)
                {
                    var today = DateTime.Today;
                    var years = today.Year - JoinDate.Value.Year;
                    if (JoinDate.Value.Date > today.AddYears(-years)) years--;
                    return years;
                }
                return null;
            }
        }

        // Dropdown Lists
        public List<SelectListItem>? Departments { get; set; }
        public List<SelectListItem>? Designations { get; set; }
        public List<SelectListItem>? SalaryGrades { get; set; }
        public List<SelectListItem>? EmployeeCategories { get; set; }
        public List<SelectListItem>? WorkSchedules { get; set; }
        public List<SelectListItem>? Genders { get; set; }
        public List<SelectListItem>? StatusList { get; set; }
        public List<SelectListItem>? BloodGroups { get; set; }

        // Navigation Properties for Display
        [Display(Name = "Department")]
        public string? DepartmentName { get; set; }

        [Display(Name = "Designation")]
        public string? DesignationName { get; set; }

        [Display(Name = "Employee Category")]
        public string? EmployeeCategoryName { get; set; }

        [Display(Name = "Work Schedule")]
        public string? WorkScheduleName { get; set; }

        [Display(Name = "Salary Grade")]
        public string? GradeName { get; set; }

        // Constructor to initialize lists
        public EmployeeVM()
        {
            InitializeDropdowns();
        }

        private void InitializeDropdowns()
        {
            Genders = new List<SelectListItem>
            {
                new SelectListItem { Value = "Male", Text = "Male" },
                new SelectListItem { Value = "Female", Text = "Female" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };

            StatusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Active", Text = "Active" },
                new SelectListItem { Value = "Inactive", Text = "Inactive" },
                new SelectListItem { Value = "Suspended", Text = "Suspended" },
                new SelectListItem { Value = "Terminated", Text = "Terminated" }
            };

            BloodGroups = new List<SelectListItem>
            {
                new SelectListItem { Value = "A+", Text = "A+" },
                new SelectListItem { Value = "A-", Text = "A-" },
                new SelectListItem { Value = "B+", Text = "B+" },
                new SelectListItem { Value = "B-", Text = "B-" },
                new SelectListItem { Value = "AB+", Text = "AB+" },
                new SelectListItem { Value = "AB-", Text = "AB-" },
                new SelectListItem { Value = "O+", Text = "O+" },
                new SelectListItem { Value = "O-", Text = "O-" }
            };

            Departments = new List<SelectListItem>();
            Designations = new List<SelectListItem>();
            SalaryGrades = new List<SelectListItem>();
            EmployeeCategories = new List<SelectListItem>();
            WorkSchedules = new List<SelectListItem>();
        }
    }
}