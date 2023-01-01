using TaskMaster.Models;

namespace TaskMaster.Commands;

public class CreateTaskCommand : ICommand
{
    private readonly string _description;
    private readonly DateTime _dueDate;

    public CreateTaskCommand(string description, DateTime dueDate)
    {
        _description = description;
        _dueDate = dueDate;
    }
    
    public void Execute(TaskItem taskItem)
    {
        taskItem.Description = _description;
        taskItem.DueDate = _dueDate;
    }
}