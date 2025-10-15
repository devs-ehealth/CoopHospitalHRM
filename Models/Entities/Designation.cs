using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class Designation
    {
        [Key]
        public int DesignationID { get; set; }

        [Required]
        [StringLength(100)]
        public string DesignationName { get; set; } = string.Empty;

        public int? EmployeeCategoryID { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeCategoryID")]
        public EmployeeCategory? EmployeeCategory { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }

}
