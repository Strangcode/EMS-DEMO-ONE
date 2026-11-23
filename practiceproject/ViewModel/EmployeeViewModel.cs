using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using practiceproject.Models;

namespace practiceproject.ViewModel
{
    public class EmployeeViewModel
    {
        // both are sam
       // public NewEmployee Employee { get; set; } = new();
        public NewEmployee Employee_ { get; set; } = new NewEmployee();

        // both are same
        public List<SelectListItem> DepartmentList { get; set; } = new List<SelectListItem>();
      //  public List<SelectList> DepartmentList_ { get; set; } = new ();

    }
}
