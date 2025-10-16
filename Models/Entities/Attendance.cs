using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        public DateTime? Date { get; set; }
        public TimeSpan? ClockIn { get; set; }
        public TimeSpan? ClockOut { get; set; }
        public TimeSpan? ShiftIn { get; set; }
        public TimeSpan? ShiftOut { get; set; }
        public TimeSpan? LunchStart { get; set; }
        public TimeSpan? LunchEnd { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? TotalHours { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? OvertimeHours { get; set; }

        [StringLength(20)]
        public string? ShiftType { get; set; }

        [StringLength(100)]
        public string? WardName { get; set; }

        public bool? IsOnCall { get; set; } = false;

        [Column(TypeName = "decimal(5,2)")]
        public decimal? OnCallHours { get; set; }

        [StringLength(20)]
        public string? AttendanceType { get; set; } = "Regular";

        [StringLength(20)]
        public string? Status { get; set; } = "Present";

        public bool? IsManualEntry { get; set; } = false;
        public int? ApprovedBy { get; set; }

        [StringLength(500)]
        public string? Comments { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }

        [ForeignKey("ApprovedBy")]
        public int? ApproverID { get; set; } 
        public Employee Approver { get; set; }
    }
}

