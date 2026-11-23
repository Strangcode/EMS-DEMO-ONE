using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using practiceproject.Models;
using practiceproject.Repository.AttendanceRepos;
using practiceproject.Repository.NewIemployee;
using practiceproject.ViewModel;

namespace practiceproject.Controllers
{
    public class AttendaceController : Controller
    {
        private readonly IAttendanceRepository _AttendenceRepo;
        private readonly NewIemployeeRepository newEmployeeReppository_;
        public AttendaceController(IAttendanceRepository Attedencrepo, NewIemployeeRepository newEmployeeReppository) 
        {
            _AttendenceRepo = Attedencrepo;
            newEmployeeReppository_ = newEmployeeReppository;
        }

        [HttpGet]
        public IActionResult Index() 
        {

            var result = _AttendenceRepo.GetAllAttendances();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {

             
            var model = new AttendanceViewModel();




            var EmployeeList = newEmployeeReppository_.GetEmployees();

            model.EmployeeList = EmployeeList.Select(x => new SelectListItem {

                Text = x.empName,
                Value = x.empId.ToString()

            }).ToList();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(AttendanceViewModel model)
        {
            if (!ModelState.IsValid)
            {

                var EmployeeList = newEmployeeReppository_.GetEmployees();

                model.EmployeeList = EmployeeList.Select(x => new SelectListItem
                {

                    Text = x.empName,
                    Value = x.empId.ToString()

                }).ToList();
                return View(model);
            }


            var check_exitsting = _AttendenceRepo.CheckAttendanceExists(model.Attendances_.EmployeeId, model.Attendances_.Date);

            if(check_exitsting==true)
            {
                ModelState.AddModelError("Attendances_.Date", "Attendance for this employee already exists for the selected date.");
                return View(model);
            }

            var result = await _AttendenceRepo.AddAttendancAsync(model.Attendances_);

            if (result == null)
            {
                ModelState.AddModelError("", "Failed to add attendance.");
                return View(model);
            }
            return RedirectToAction("Index");
        }

    }
}
