using System.ComponentModel.DataAnnotations;

namespace CoopHospitalHRM.Models.Entities
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        public int? AnnualLimit { get; set; }
        public bool? CanCarryForward { get; set; } = false;
        public int? MaxCarryForward { get; set; }
        public bool? RequiresApproval { get; set; } = true;

        [StringLength(10)]
        public string? ColorCode { get; set; }

        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<Leave>? Leaves { get; set; }
        public ICollection<LeaveBalance>? LeaveBalances { get; set; }
    }

}
