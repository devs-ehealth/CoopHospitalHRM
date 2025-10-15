using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class EPFETFInfo
    {
        [Key]
        public int EPFETFID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string? EPFNumber { get; set; }

        [StringLength(50)]
        public string? ETFNumber { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? EPFPercentage { get; set; } = 8.00m;

        [Column(TypeName = "decimal(5,2)")]
        public decimal? ETFPercentage { get; set; } = 3.00m;

        public DateTime? EffectiveDate { get; set; } = DateTime.Now;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }
    }
}
