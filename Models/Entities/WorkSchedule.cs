using System.ComponentModel.DataAnnotations;

namespace CoopHospitalHRM.Models.Entities
{
    public class WorkSchedule
    {
        [Key]
        public int WorkScheduleID { get; set; }

        [StringLength(100)]
        public string? ScheduleName { get; set; }

        [StringLength(20)]
        public string? ScheduleType { get; set; }

        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? BreakMinutes { get; set; } = 60;

        [StringLength(255)]
        public string? Description { get; set; }

        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public ICollection<Employee>? Employees { get; set; }
    }
}
