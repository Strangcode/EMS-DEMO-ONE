using Microsoft.AspNetCore.Mvc;
using practiceproject.DbContextData;
using practiceproject.Models;
using practiceproject.ViewModel;
using practiceproject.HelperClasses;

namespace practiceproject.Controllers
{
    public class AuthentiCationController : Controller
    {
        private readonly ContextClass contextClass_;

        public AuthentiCationController(ContextClass contextClass)
        {
            contextClass_ = contextClass;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegisterViewModel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterViewModel(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(model ==null)
            {
                return View(model);
            }

            var haspasseord = PasswordHasher.Passwordhashing(model.Password);

            if (haspasseord != null) {

                var ObjectUser = new UserRegistration()
                {
                    Email = model.Email,
                    PasswordHash = haspasseord,
                };
                if (ObjectUser != null) 
                {
                    contextClass_.RegisterUsers.Add(ObjectUser);
                    contextClass_.SaveChanges();
                    return RedirectToAction("Login", "AuthentiCation");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "AuthentiCation");
        }
        [HttpPost]
       public IActionResult Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(model == null)
            {
                return View(model);
            }
            
            var user = contextClass_.RegisterUsers.FirstOrDefault(u => u.Email == model.Email);

            if (user == null) 
            {
                return View(model);
            }

            var varifypassword = PasswordHasher.VerifyPassword(model.Password, user.PasswordHash);

            if (!varifypassword)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
            else
            {
                // we will use session to store user information after successful login

                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("userRole", user.Role);   

                // Authentication successful, redirect to a secure page or dashboard

                return RedirectToAction("Index", "DashBoard");
            }

        }

    }
}
