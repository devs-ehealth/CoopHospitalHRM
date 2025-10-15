using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class OnCallSchedule
    {
        [Key]
        public int OnCallID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        public DateTime? OnCallDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? DepartmentID { get; set; }

        [StringLength(20)]
        public string? Status { get; set; } = "Scheduled";

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }

        [ForeignKey("DepartmentID")]
        public Department? Department { get; set; }
    }
}
