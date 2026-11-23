using Microsoft.AspNetCore.Mvc.Rendering;
using practiceproject.Models;

namespace practiceproject.ViewModel
{
    public class AttendanceViewModel
    {

        public Attendance? Attendances_ { get; set; }
        public List<SelectListItem>? EmployeeList { get; set; }

    }
}
