using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class Leave
    {
        [Key]
        public int LeaveID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int LeaveTypeID { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? TotalDays { get; set; }

        [StringLength(500)]
        public string? Reason { get; set; }

        [StringLength(20)]
        public string? Status { get; set; } = "Pending";

        public DateTime? AppliedDate { get; set; } = DateTime.Now;
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        [StringLength(500)]
        public string? RejectionReason { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }

        [ForeignKey("LeaveTypeID")]
        public LeaveType? LeaveType { get; set; }

        [ForeignKey("ApprovedBy")]
        public Employee? Approver { get; set; }
    }


}
