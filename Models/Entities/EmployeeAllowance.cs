using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class EmployeeAllowance
    {
        [Key]
        public int EmployeeAllowanceID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int AllowanceID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }

        public DateTime? EffectiveDate { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }

        [ForeignKey("AllowanceID")]
        public HospitalAllowance? HospitalAllowance { get; set; }
    }
}
