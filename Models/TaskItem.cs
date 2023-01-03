using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

    public TaskMemento Save()
    {
        return TaskMemento.Snapshot(this);
    }

    public void Restore(TaskMemento taskMemento)
    {
        Description = taskMemento.Description;
        DueDate = taskMemento.DueDate;
        IsCompleted = taskMemento.IsCompleted;
    }
}