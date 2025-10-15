using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class SalaryGrade
    {
        [Key]
        public int GradeID { get; set; }

        [Required]
        [StringLength(50)]
        public string GradeName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? BasicSalary { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<SalaryStructure>? SalaryStructures { get; set; }
    }

}
