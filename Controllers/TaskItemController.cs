using Microsoft.AspNetCore.Mvc;
using TaskMaster.Models;
using TaskMaster.Services;

namespace TaskMaster.Controllers;

public class TaskItemController : Controller
{
    private readonly TaskService _taskService;

    public TaskItemController(TaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<ActionResult> Index()
    {
        var tasks = await _taskService.GetTasks();
        return View(tasks);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(TaskViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _taskService.CreateTask(model.Description, model.DueDate);
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        var task = _taskService.GetTask(id);
        if (task == null)
        {
            return RedirectToAction("Index");
        }

        return View(task);
    }

    [HttpPost]
    public ActionResult Edit(TaskItem taskItem)
    {
        if (!ModelState.IsValid)
        {
            return View(taskItem);
        }

        _taskService.UpdateTask(taskItem);
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var task = _taskService.GetTask(id);
        if (task == null)
        {
            return RedirectToAction("Index");
        }

        return View(task);
    }

    [HttpPost]
    public ActionResult Delete(TaskItem taskItem)
    {
        _taskService.DeleteTask(taskItem);
        return RedirectToAction("Index");
    }
}
