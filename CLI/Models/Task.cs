using CLI.Enums;

public class Task
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public Status Status { get; set; } = Status.TODO;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
}
