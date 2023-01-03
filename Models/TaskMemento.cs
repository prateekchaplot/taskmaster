using TaskMaster.Interfaces;

namespace TaskMaster.Models;

public class TaskMemento : IMemento
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ActionDate { get; set; }

    public static TaskMemento Snapshot(TaskItem task)
    {
        return new TaskMemento
        {
            TaskId = task.Id,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            DueDate = task.DueDate,
            ActionDate = DateTime.Now
        };
    }
}