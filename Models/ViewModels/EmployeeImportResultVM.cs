namespace CoopHospitalHRM.Models.ViewModels
{
    public class EmployeeImportResultVM
    {
        public int RowNumber { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // Success, Error, Warning
        public string Message { get; set; } = string.Empty;
    }

}
