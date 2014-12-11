using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LeaveSystem.Domain.Abstract;
using LeaveSystem.Domain.Entities;

namespace LeaveSystem.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository projectRepository;
        private ITaskRepository taskRepository;

        public ProjectController(IProjectRepository projectRepo,ITaskRepository taskRepo)
        {
            projectRepository = projectRepo;
            taskRepository = taskRepo;
        }

        public ViewResult Index()
        {
            return View(projectRepository.Projects);
        }

        public ViewResult Details(int? projectId)
        {
            Project project = projectRepository.Projects.Where(p => p.Id == projectId).FirstOrDefault();

            return View(project);
        }

        public ViewResult Edit(int taskId)
        {
            Projecttask task = taskRepository.Tasks
                .FirstOrDefault(t => t.TaskId == taskId);

            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(Projecttask task)
        {
            if (ModelState.IsValid)
            {
                taskRepository.SaveTask(task);

                TempData["message"] = string.Format("{0} has been saved", task.TaskName);

                return RedirectToAction("Details", new { projectId = task.ProjectId});
            }
            else
            {
                return View(task);
            }
        }

        public ViewResult Create(int projectId)
        {
            ViewBag.projectId = projectId;

            return View("Edit", new Projecttask());
        }

        [HttpPost]
        public ActionResult Deletetask(int taskId, int projectId=0)
        {
            Projecttask deletedTask = taskRepository.DeleteTask(taskId);

            if (deletedTask != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedTask.TaskName);
            }

            return RedirectToAction("Details", "Project", new { projectId = projectId});

        }

        [HttpPost]
        public ActionResult Deleteproject(int projectId)
        {
            Project deletedProject = projectRepository.DeleteProject(projectId);

            if (deletedProject != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProject.ProjectTitle);
            }

            return RedirectToAction("Index");
        }
	}
}