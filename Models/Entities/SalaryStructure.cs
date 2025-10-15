using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class SalaryStructure
    {
        [Key]
        public int SalaryStructureID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? BasicSalary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? FixedAllowances { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MedicalAllowance { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TransportAllowance { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? OtherAllowances { get; set; } = 0;

        public int? GradeID { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }

        [ForeignKey("GradeID")]
        public SalaryGrade? SalaryGrade { get; set; }
    }
}
