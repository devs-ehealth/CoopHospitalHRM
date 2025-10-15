using System.ComponentModel.DataAnnotations;

namespace CoopHospitalHRM.Models.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [StringLength(20)]
        public string? DepartmentCode { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? DepartmentType { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public ICollection<Employee>? Employees { get; set; }
    }

}
