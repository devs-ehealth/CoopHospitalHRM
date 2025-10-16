using HospitalHRM.Models.ViewModels;

namespace CoopHospitalHRM.Models.ViewModels
{
    public class EmployeeEditVM : EmployeeVM
    {
        public string? CurrentEmail { get; set; }
        public string? CurrentNIC { get; set; }
    }

}
