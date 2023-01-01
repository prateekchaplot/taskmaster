using TaskMaster.Models;

namespace TaskMaster.Commands;

public interface ICommand
{
    void Execute(TaskItem taskItem);
}