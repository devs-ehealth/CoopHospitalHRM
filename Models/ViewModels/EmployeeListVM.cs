using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoopHospitalHRM.Models.ViewModels
{
    public class EmployeeListVM
    {
        // Properties for individual employee
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? DesignationName { get; set; }
        public string? DepartmentName { get; set; }
        public string? EmployeeCategoryName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? JoinDate { get; set; }
        public string Status { get; set; } = "Active";
        public int? YearsOfService { get; set; }

        // Properties for the list view
        public List<EmployeeListVM>? Employees { get; set; }

        // Search and filter properties
        public string? SearchTerm { get; set; }
        public string? DepartmentFilter { get; set; }
        public string? StatusFilter { get; set; }

        // Pagination
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public List<SelectListItem>? DepartmentFilters { get; set; }
        public List<SelectListItem>? StatusFilters { get; set; }
    }
}