using HospitalHRM.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CoopHospitalHRM.Models.ViewModels
{
    public class EmployeeImportVM
    {
        [Display(Name = "Import File")]
        [Required(ErrorMessage = "Please select a file to import")]
        public IFormFile? ImportFile { get; set; }

        [Display(Name = "Update Existing Records")]
        public bool UpdateExisting { get; set; } = false;

        [Display(Name = "Send Welcome Email")]
        public bool SendWelcomeEmail { get; set; } = false;

        public List<EmployeeImportResultVM>? ImportResults { get; set; }
    }

}
