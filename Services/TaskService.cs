using TaskMaster.Commands;
using TaskMaster.Models;

namespace TaskMaster.Services;

public class TaskService
{
    private readonly List<TaskItem> _tasks;

    public TaskService()
    {
        _tasks = new List<TaskItem>();
    }

    public TaskItem GetTask(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public List<TaskItem> GetTasks()
    {
        return _tasks;
    }

    public void CreateTask(string description, DateTime dueDate)
    {
        var command = new CreateTaskCommand(description, dueDate);
        var taskItem = new TaskItem();
        ExecuteCommand(command, taskItem);
        _tasks.Add(taskItem);
    }

    public void UpdateTask(TaskItem taskItem)
    {
        var command = new UpdateTaskCommand(taskItem.Description, taskItem.DueDate, taskItem.IsCompleted);
        ExecuteCommand(command, taskItem);
    }

    public void DeleteTask(TaskItem taskItem)
    {
        var command = new DeleteTaskCommand();
        ExecuteCommand(command, taskItem);
        _tasks.Remove(taskItem);
    }

    public void ExecuteCommand(ICommand command, TaskItem taskItem)
    {
        command.Execute(taskItem);
    }
}
