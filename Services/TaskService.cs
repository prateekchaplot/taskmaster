using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Commands;
using TaskMaster.Models;

namespace TaskMaster.Services;

public class TaskService
{
    private readonly ILogger<TaskService> _logger;
    private readonly AppDbContext _context;

    public TaskService(ILogger<TaskService> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public TaskItem GetTask(int id)
    {
        return _context.Tasks.FirstOrDefault(t => t.Id == id);
    }

    public async Task<List<TaskItem>> GetTasks()
    {
        var tasks = await _context.Tasks.ToListAsync();
        _logger.LogInformation("[GetTasks] {tasks}", JsonSerializer.Serialize(tasks));
        return tasks;
    }

    public void CreateTask(string description, DateTime dueDate)
    {
        var command = new CreateTaskCommand(description, dueDate);
        var taskItem = new TaskItem();
        ExecuteCommand(command, taskItem);
        _context.Tasks.Add(taskItem);
        _context.SaveChanges();
    }

    public void UpdateTask(TaskItem taskItem)
    {
        var command = new UpdateTaskCommand(taskItem);
        ExecuteCommand(command, taskItem);
        _context.Update(taskItem);
        _context.SaveChanges();
    }

    public void DeleteTask(TaskItem taskItem)
    {
        var command = new DeleteTaskCommand();
        ExecuteCommand(command, taskItem);
        _context.Remove(taskItem);
        _context.SaveChanges();
    }

    public void ExecuteCommand(ICommand command, TaskItem taskItem)
    {
        command.Execute(taskItem);
    }
}
