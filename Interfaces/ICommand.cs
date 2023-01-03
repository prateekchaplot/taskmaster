using TaskMaster.Models;

namespace TaskMaster.Interfaces;

public interface ICommand
{
    void Execute(TaskItem taskItem);
}