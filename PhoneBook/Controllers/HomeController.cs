using System.Web.Mvc;
using PhoneBook.ViewModels.Home;
using PhoneBook.Models;


namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (this.ModelState.IsValid)
            {
                AuthenticationManager.Authenticate(model.Username, model.Password);

                if (AuthenticationManager.LoggedUser == null)
                    ModelState.AddModelError("authenticationFailed", "Wrong username or password!");
            }

            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Home");
        }
	}
}