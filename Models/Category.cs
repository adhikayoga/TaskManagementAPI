using System.Text.Json.Serialization;

namespace TaskManagementAPI.Models;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsDeleted { get; set; } = false;

    [JsonIgnore]
    public ICollection<TaskItem>? Tasks { get; set; }
}