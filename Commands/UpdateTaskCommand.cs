using TaskMaster.Models;

namespace TaskMaster.Commands;

public class UpdateTaskCommand : ICommand
{
    private readonly string _description;
    private readonly DateTime _dueDate;
    private readonly bool _isCompleted;

    public UpdateTaskCommand(string description, DateTime dueDate, bool isCompleted)
    {
        _description = description;
        _dueDate = dueDate;
        _isCompleted = isCompleted;
    }

    public void Execute(TaskItem taskItem)
    {
        taskItem.Description = _description;
        taskItem.DueDate = _dueDate;
        taskItem.IsCompleted = _isCompleted;
    }
}