using TaskMaster.Interfaces;
using TaskMaster.Models;

namespace TaskMaster.Commands;

public class UpdateTaskCommand : ICommand
{
    private readonly string _description;
    private readonly DateTime _dueDate;
    private readonly bool _isCompleted;

    public UpdateTaskCommand(TaskItem task)
    {
        _description = task.Description;
        _dueDate = task.DueDate;
        _isCompleted = task.IsCompleted;
    }

    public void Execute(TaskItem taskItem)
    {
        taskItem.Description = _description;
        taskItem.DueDate = _dueDate;
        taskItem.IsCompleted = _isCompleted;
    }
}