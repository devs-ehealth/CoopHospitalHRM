using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class ETFContribution
    {
        [Key]
        public int ContributionID { get; set; }

        [Required]
        public int PayrollID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? EmployerContribution { get; set; }

        public DateTime? ContributionDate { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        [ForeignKey("PayrollID")]
        public Payroll? Payroll { get; set; }
    }
}
