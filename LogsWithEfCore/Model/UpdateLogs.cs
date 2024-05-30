namespace LogsWithEfCore.Model;

public class UpdateLogs : BaseEntity
{
    public string TableName { get; set; }
    public long UpdatedEntityId { get; set; }
    public long UpdateByUserId { get; set; }
    public User User { get; set; }
    public string Field { get; set; }
    public string NewValue { get; set; }
    public string OldValue { get; set; }
}
