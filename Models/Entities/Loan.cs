using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LoanAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? EMIAmount { get; set; }

        public int? TotalInstallments { get; set; }
        public int? InstallmentsPaid { get; set; } = 0;
        public DateTime? LoanStartDate { get; set; }
        public DateTime? LoanEndDate { get; set; }

        [StringLength(20)]
        public string? Status { get; set; } = "Active";

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }
    }
}
