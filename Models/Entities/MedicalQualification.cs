using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoopHospitalHRM.Models.Entities
{
    public class MedicalQualification
    {
        [Key]
        public int QualificationID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [StringLength(200)]
        public string? DegreeName { get; set; }

        [StringLength(200)]
        public string? University { get; set; }

        public int? YearCompleted { get; set; }

        [StringLength(100)]
        public string? RegistrationNo { get; set; }

        [StringLength(200)]
        public string? Specialization { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        [ForeignKey("EmployeeID")]
        public Employee? Employee { get; set; }
    }
}
