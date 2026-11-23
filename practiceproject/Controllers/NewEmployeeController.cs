using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using practiceproject.DbContextData;
using practiceproject.Models;
using practiceproject.Repository;
using practiceproject.Repository.NewIemployee;
using practiceproject.ViewModel;

namespace practiceproject.Controllers
{
    public class NewEmployeeController : Controller
    {

        private readonly ContextClass _context;
        private readonly IDepartment _departmentRepository;
        private readonly NewIemployeeRepository _employeeRepository;

        public NewEmployeeController(IDepartment departmentRepository, ContextClass context, NewIemployeeRepository newIemployeeRepository)
        {
            _departmentRepository = departmentRepository;
            _context = context;
            _employeeRepository = newIemployeeRepository;
        }

        //public NewEmployeeController(ContextClass context)
        //{
        //    _context = context;
        //}


        public IActionResult Details( Guid id) 
        { 

            var employees = _employeeRepository.GetEmployeeById(id);

            return View(employees);

        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {

            var employees = _employeeRepository.GetEmployeeById(id);

            return View(employees);

        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Guid empId)
        {

            var employee = _employeeRepository.DeleteEmployee(empId);

            if (employee == null)
            {
                return NotFound();
            }

            

            return RedirectToAction("Index", "NewEmployee");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeViewModel();

            model.Employee_ = employee;

            var departments = _departmentRepository.GetAllDepartment();

            model.DepartmentList = departments.Select(x => new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.Departid.ToString()
            }).ToList();

            return View(model);
        }


        [HttpPost]
        public IActionResult Update(EmployeeViewModel employee)
        {

            if (employee.Employee_ == null)
            {
                employee.Employee_ = new NewEmployee();
            }

            if (!ModelState.IsValid)
            {
                var departments = _departmentRepository.GetAllDepartment();


                employee.DepartmentList = departments.Select(x => new SelectListItem
                {

                    Text = x.DepartmentName,
                    Value = x.Departid.ToString()


                }).ToList();
                return View("Edit", employee);

            }

            var result = _employeeRepository.UpdateEmployee(employee.Employee_);

            return View("Index","NewEmployee");
        }


        public IActionResult Index()
        {

            var Employee = _employeeRepository.GetEmployees();


            return View(Employee);
        }

        [ HttpGet]
        public IActionResult Create()
        {

            var model = new EmployeeViewModel();

            var departments = _departmentRepository.GetAllDepartment();

            model.DepartmentList = departments.Select(x => new SelectListItem {

                Text = x.DepartmentName,
                Value = x.Departid.ToString()

            }).ToList();


            return View(model);
         }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel model) 
        {

            if (model.Employee_ == null)
            {
                model.Employee_ = new NewEmployee();
            }


            if (!ModelState.IsValid)
            {
                var departments = _departmentRepository.GetAllDepartment();


                model.DepartmentList = departments.Select(x => new SelectListItem
                {

                    Text = x.DepartmentName,
                    Value = x.Departid.ToString() 


                }).ToList();
                




                return View(model);
            }

           var result = _employeeRepository.CreateEmployee(model.Employee_);
            return RedirectToAction("Index","NewEmployee");
        }

    }
}
