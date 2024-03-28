// File: ToDoItem.cs
namespace ToDoApplication.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public TimeSpan TimeLeft { get; set; }
    }
}
