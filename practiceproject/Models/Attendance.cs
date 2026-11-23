using System.ComponentModel.DataAnnotations;

namespace practiceproject.Models
{

    public enum AttendanceStatus 
    {
    
        Absent,
        Present,
        Leave

    }

    public class Attendance
    {
        [Key]
        public Guid Attendanceid { get; set; } = Guid.NewGuid();
        [Required]
        public Guid EmployeeId { get; set; }
        [Required(ErrorMessage ="Please enter Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="Please Enter status")]
        public AttendanceStatus Status { get; set; }
        public NewEmployee? Employee { get; set; }

    }
}
