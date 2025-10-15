using System.ComponentModel.DataAnnotations;

namespace CoopHospitalHRM.Models.Entities
{
    public class EmployeeCategory
    {
        [Key]
        public int EmployeeCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? CategoryType { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Designation>? Designations { get; set; }
    }

}
