using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class PayrollTransaction
    {
        [Key]
        public int TransactionID { get; set; }

        [Required]
        public int PayrollID { get; set; }

        [StringLength(50)]
        public string? TransactionType { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }

        [StringLength(100)]
        public string? Reference { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        [ForeignKey("PayrollID")]
        public Payroll? Payroll { get; set; }
    }
}
