namespace TodoListApp.Models;

internal class Todo
{
    public string Activity { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;

}
