using System.ComponentModel.DataAnnotations;

namespace CoopHospitalHRM.Models.Entities
{
    public class SystemRole
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? RoleType { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<SystemUser>? SystemUsers { get; set; }
    }
}
