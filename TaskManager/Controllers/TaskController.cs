using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models.Context;
using TaskManager.Models.DbModel;
using TaskManager.Models.Dto;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult FinishTask(int id)
        {
            Context.Load();
            Tasks task = Context.Tasks.Where(x => x.Id == id).FirstOrDefault();

            task.Finished = DateTime.Now;

            Context.Save();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Create()
        {
            Context.Load();
            List<User> users = Context.User;
            this.ViewBag.Users = users;

            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateTaskDto newTaskDto)
        {
            Tasks newTask = new Tasks();
            newTask.Id = Context.AutoIncrement();
            newTask.AssignedBy = this.HttpContext.Session.GetInt32("loggedInID") ?? -1;
            newTask.Name = newTaskDto.Name;
            newTask.Assigment = newTaskDto.Assigment;
            newTask.StartDate = new DateTime(newTaskDto.StartDate.Year, newTaskDto.StartDate.Month, newTaskDto.StartDate.Day, newTaskDto.StartHours, newTaskDto.StartMinutes, 0);
            newTask.EndDate = new DateTime(newTaskDto.EndDate.Year, newTaskDto.EndDate.Month, newTaskDto.EndDate.Day, newTaskDto.EndHours, newTaskDto.EndMinutes, 0);

            UserTask userTask = new UserTask();
            userTask.TaskId = newTask.Id;
            userTask.UserId = newTaskDto.AssignedTo;

            Context.Tasks.Add(newTask);
            Context.UserTask.Add(userTask);

            Context.Save();

            return RedirectToAction("Index","Home");
        }
        public ActionResult Delete(int id)
        {
            Context.Load();
            Tasks removingTask = Context.Tasks.Where(x => x.Id == id).FirstOrDefault();
            List<UserTask> removingUserTask = Context.UserTask.Where(x => x.TaskId == id).ToList();

            Context.Tasks.Remove(removingTask);
            foreach (UserTask userTask in removingUserTask)
            {
                Context.UserTask.Remove(userTask);
            }
            Context.Save();

            return RedirectToAction("Index", "Home");
        }
    }
}
