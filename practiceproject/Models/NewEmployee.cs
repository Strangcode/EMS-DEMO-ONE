using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practiceproject.Models
{
    public class NewEmployee
    {
        [Key]
        public Guid empId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Employee name is required")]
        public string? empName { get; set; }
        [Required(ErrorMessage = "Employee email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? empEmail { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string? phoneNumber { get; set; }

        public Guid departmentId { get; set; }

        //[Required(ErrorMessage = "Department is required")]
        [ForeignKey(nameof(departmentId))]
        public Department? department { get; set; }

        [Required(ErrorMessage = "Employee position is required")]
        public string? empPosition { get; set; }
        [Precision(18, 2)]
        [Required(ErrorMessage = "Employee salary is required")]
        public decimal empSalary { get; set; }

        [Required(ErrorMessage = "Employee joining date is required")]
        public DateTime empJoiningDate { get; set; } = DateTime.Now;




    }
}
