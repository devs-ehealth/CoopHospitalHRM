using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class EmployeePerformance
    {
        [Key]
        public int PerformanceID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        public DateTime? ReviewDate { get; set; }

        [Required]
        public int ReviewerID { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal? PerformanceRating { get; set; }

        [StringLength(1000)]
        public string? Comments { get; set; }

        [StringLength(1000)]
        public string? Goals { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }

        [ForeignKey("ReviewerID")]
        public Employee? Reviewer { get; set; }
    }
}
