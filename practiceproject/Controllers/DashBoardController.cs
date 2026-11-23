using Microsoft.AspNetCore.Mvc;
using practiceproject.DbContextData;
using practiceproject.Models;

namespace practiceproject.Controllers
{
    public class DashBoardController : Controller
    {

        private readonly ContextClass _contextClass;

        public DashBoardController(ContextClass contextClass)
        {
            _contextClass = contextClass;
        }

        //private readonly ContextClass contextClass_;

        public IActionResult Index()
        {
            var userid = HttpContext.Session.GetString("UserId");

            if(string.IsNullOrEmpty(userid))
            {
                return RedirectToAction("Login", "AuthentiCation");
            }

            var todate = DateTime.Today.Date;

           // var PresentTodayEmployee = _contextClass.Attendancess.Where(x => x.Date.Date == todate.Date && x.Status.Equals("Present")).Count();

            var presentTodayEmployee = _contextClass.Attendancess
    .Count(x => x.Date.Date == todate.Date &&
                x.Status == AttendanceStatus.Present);


            ViewBag.TotalEmployee = _contextClass.NewEmployees.Count();
            ViewBag.TotalDepartment = _contextClass.Departments.Count();
            ViewBag.TotalAttendance = _contextClass.Attendancess.Count();
            ViewBag.PresentTodayEmployee = presentTodayEmployee;


            return View();
        }
    }
}
