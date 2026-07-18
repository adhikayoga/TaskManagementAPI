using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? DueDate { get; set; }

    public bool IsDeleted { get; set; } = false;

    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public int StatusId { get; set; }

    public Status? Status { get; set; }
}