using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practiceproject.Models;
using practiceproject.Repository;

namespace practiceproject.Controllers
{
    public class EmployeeController1 : Controller
    {
        // GET: EmployeeController1

        private readonly EmployeeRepository Emprepo;

        public EmployeeController1()
        {
            Emprepo = new EmployeeRepository();
        }

        public ActionResult Index()
        {

            List<Employee> obj = Emprepo.GetEmployees();
            return View(obj);
        }

        // GET: EmployeeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee collection)
        {
            if (ModelState.IsValid)
            {
                Emprepo.AddEmployee(collection);

                return RedirectToAction(nameof(Index));
            }

            return View(collection);

        }

        // GET: EmployeeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var empl = Emprepo.GetElementByid(id);
            return View(empl);
        }

        // POST: EmployeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {

            return View();

        }

        // GET: EmployeeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
