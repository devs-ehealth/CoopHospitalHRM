using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class LeaveBalance
    {
        [Key]
        public int LeaveBalanceID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public int LeaveTypeID { get; set; }

        public int? Year { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? TotalEntitlement { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Used { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Balance { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal? CarriedForward { get; set; } = 0;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }

        [ForeignKey("LeaveTypeID")]
        public LeaveType? LeaveType { get; set; }
    }

}
