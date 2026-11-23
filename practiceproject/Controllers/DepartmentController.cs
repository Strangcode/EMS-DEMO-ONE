using Microsoft.AspNetCore.Mvc;
using practiceproject.DbContextData;
using practiceproject.Models;
using practiceproject.Repository;

namespace practiceproject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _Departmentrepo;

        public DepartmentController(IDepartment departmentRepository)
        {
            _Departmentrepo = departmentRepository;
        }
        public IActionResult Index()
        {
            var departments = _Departmentrepo.GetAllDepartment();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department) 
        {
             var result = _Departmentrepo.AddDepartment(department);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Failed to create department.");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _Departmentrepo.GetDepartmentEdit(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult EditConfirm(Department Obj) 
        {
          if (!ModelState.IsValid)
            {
                return View(Obj);
            }
            if (Obj == null)
            {
                return NotFound();
            }
            var result = _Departmentrepo.UpdateDepartment(Obj);

            if (result)
            {
                return RedirectToAction("Index","Department");
            }
            else
            {
                ModelState.AddModelError("", "Failed to update department.");
            }


            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid id) 
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _Departmentrepo.GetDepartmentDelete(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(Guid id) 
        {
            var result = _Departmentrepo.DeleteDepartment(id);

            if (result == null)
            {
               
                ModelState.AddModelError("", "Failed to delete department.");
            }
            else
            {
                return RedirectToAction("Index", "Department");
            }

            return View();
        }

    }
}
