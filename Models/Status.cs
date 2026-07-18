using System.Text.Json.Serialization;

namespace TaskManagementAPI.Models;

public class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<TaskItem>? Tasks { get; set; }
}