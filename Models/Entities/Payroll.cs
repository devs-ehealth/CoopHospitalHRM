using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class Payroll
    {
        [Key]
        public int PayrollID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        public DateTime? PayPeriodStart { get; set; }
        public DateTime? PayPeriodEnd { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? BasicSalary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Allowances { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Bonuses { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Deductions { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetPay { get; set; }

        public DateTime? GeneratedDate { get; set; } = DateTime.Now;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }

        public ICollection<PayrollTransaction>? PayrollTransactions { get; set; }
        public ICollection<EPFContribution>? EPFContributions { get; set; }
        public ICollection<ETFContribution>? ETFContributions { get; set; }
    }
}
