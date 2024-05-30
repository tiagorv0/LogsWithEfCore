using System.ComponentModel.DataAnnotations;

namespace LogsWithEfCore.Model;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
}
