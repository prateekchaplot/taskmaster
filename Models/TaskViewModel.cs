using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models;

public class TaskViewModel
{
    [Required]
    public string Description { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
}
