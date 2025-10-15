using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class HospitalAllowance
    {
        [Key]
        public int AllowanceID { get; set; }

        [StringLength(100)]
        public string? AllowanceName { get; set; }

        [StringLength(50)]
        public string? AllowanceCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }

        [StringLength(50)]
        public string? AllowanceType { get; set; }

        [StringLength(20)]
        public string? ApplicableTo { get; set; }

        public bool? IsTaxable { get; set; } = true;
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<EmployeeAllowance>? EmployeeAllowances { get; set; }
    }
}
