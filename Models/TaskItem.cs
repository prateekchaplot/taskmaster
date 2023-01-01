namespace TaskMaster.Models;

public class TaskItem
{
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}