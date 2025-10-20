using CoopHospitalHRM.Models.Entities;
using System.ComponentModel.DataAnnotations;

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

    // Navigation property
    public virtual ICollection<Employee>? Employees { get; set; }
}