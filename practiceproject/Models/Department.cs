
using System.ComponentModel.DataAnnotations;

namespace practiceproject.Models
{
    public class Department
    {
        [Key]
        public Guid Departid { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Department name is required.")]
        public string DepartmentName { get; set; }
       
        public string DepartmentDescription { get; set; } = string.Empty;
    }
}
