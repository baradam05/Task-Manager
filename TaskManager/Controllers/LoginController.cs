using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models.Context;
using TaskManager.Models.DbModel;

namespace TaskManager.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        public IActionResult Index(User logedInUser)
        {
            User? dbUser = Context.User.Where(x => x.Username == logedInUser.Username && x.Password == logedInUser.Password).FirstOrDefault();

            if(dbUser == null)
            {
                return RedirectToAction("Index");
            }

            this.HttpContext.Session.SetInt32("loggedInID",dbUser.Id);

            return RedirectToAction("Index","Home");
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.SetInt32("loggedInID", -1);

            return RedirectToAction("Index");
        }
    }
}
