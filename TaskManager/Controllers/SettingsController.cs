using Microsoft.AspNetCore.Mvc;
using TaskManager.Models.Context;
using TaskManager.Models.DbModel;

namespace TaskManager.Controllers
{
    public class SettingsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(Context.settings);
        }

        [HttpPost]
        public IActionResult Index(Settings settings)
        {
            Context.settings = settings;
            if(settings.Context == "localRadio")
            {
                Context.SetContext(new JsContext());
            }
            else
            {
                Context.SetContext(new MyContext());
            }
            return RedirectToAction("Index");
        }
    }
}
