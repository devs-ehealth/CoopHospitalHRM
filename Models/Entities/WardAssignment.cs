using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class WardAssignment
    {
        [Key]
        public int AssignmentID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [StringLength(100)]
        public string? WardName { get; set; }

        public DateTime? AssignmentDate { get; set; }

        [StringLength(20)]
        public string? Shift { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }
    }
}
