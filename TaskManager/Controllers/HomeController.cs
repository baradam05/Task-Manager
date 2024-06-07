using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol;
using System.Diagnostics;
using TaskManager.Models;
using TaskManager.Models.Context;
using TaskManager.Models.DbModel;
using TaskManager.Models.Dto;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Context.SetContext(new JsContext());
            string str = Context.settings.JsPath;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Context.Load();

            int loggedInId = this.HttpContext.Session.GetInt32("loggedInID") ?? -1;

            if (loggedInId == -1)
            {
                return RedirectToAction("Index","Login");
            }

            string? filterJson = this.HttpContext.Session.GetString("filter");
            FilterDto filter = new FilterDto() { Overdue = true, Intime = true };
            if(filterJson != null)
            {
                filter = filterJson.FromJson<FilterDto>();
            }

            List<UserTask> userTasks = Context.UserTask.Where(x => x.UserId == this.HttpContext.Session.GetInt32("loggedInID")).ToList();

            List<TaskDto> tasksDto = new List<TaskDto>();
            List<TaskDto> finishedTasksDto = new List<TaskDto>();

            foreach (UserTask ut in userTasks)
            {
                Tasks task = Context.Tasks.Where(x => x.Id == ut.TaskId).FirstOrDefault();

                #region filter
                bool overdue = task.EndDate < DateTime.Now;

                if (filter.Overdue && overdue) { }
                else if (filter.Intime && !overdue) { }
                else
                    continue;
                #endregion

                TaskDto taskDto = new TaskDto(
                    task.Id,
                    task.Name,
                    task.Assigment,
                    Context.User.Where(x => x.Id == ut.UserId).FirstOrDefault().Username,
                    task.StartDate,
                    task.EndDate);

                if(task.Finished != null)
                {
                    finishedTasksDto.Add(taskDto);
                }
                else
                {
                    tasksDto.Add(taskDto);
                }
            }

            #region Order by filter
            Func<TaskDto, object> orderBy;

            if(filter.OrderBy == "Start")
            {
                orderBy = (x => x.From);
            }
            else if (filter.OrderBy == "End")
            {
                orderBy = (x => x.To);
            }
            else
            {
                orderBy = (x => x.Name);
            }

            if(filter.OrderType == "Descending")
            {
                tasksDto = tasksDto.OrderByDescending(orderBy).ToList();
            }
            else
            {
                tasksDto = tasksDto.OrderBy(orderBy).ToList();
            }
            #endregion

            this.ViewBag.Tasks = tasksDto;
            this.ViewBag.FinishedTasks = finishedTasksDto;

            return View(filter);
        }

        [HttpPost]
        public IActionResult Index(FilterDto filter)
        {
            string filterJson = filter.ToJson();

            this.HttpContext.Session.SetString("filter", filterJson);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
