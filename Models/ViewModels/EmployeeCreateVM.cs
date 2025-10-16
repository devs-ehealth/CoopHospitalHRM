using HospitalHRM.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CoopHospitalHRM.Models.ViewModels
{
    public class EmployeeCreateVM : EmployeeVM
    {
        [Display(Name = "Create User Account")]
        public bool CreateUserAccount { get; set; } = false;

        [Display(Name = "Username")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public string? Username { get; set; }

        [Display(Name = "Temporary Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
        public string? TemporaryPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("TemporaryPassword", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
