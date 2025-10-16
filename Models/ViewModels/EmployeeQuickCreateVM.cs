using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CoopHospitalHRM.Models.ViewModels
{
    public class EmployeeQuickCreateVM
    {
        [Required(ErrorMessage = "Employee Code is required")]
        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "NIC is required")]
        [Display(Name = "NIC")]
        public string NIC { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [Display(Name = "Designation")]
        public int DesignationID { get; set; }

        // Dropdowns for quick create
        public List<SelectListItem>? Departments { get; set; }
        public List<SelectListItem>? Designations { get; set; }
    }

}
