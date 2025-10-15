using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class SystemUser
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [StringLength(50)]
        public string? Username { get; set; }

        [StringLength(255)]
        public string? PasswordHash { get; set; }

        public int? RoleID { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }

        [ForeignKey("RoleID")]
        public SystemRole? SystemRole { get; set; }
    }
}
