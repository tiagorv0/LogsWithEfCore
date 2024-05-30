using LogsWithEfCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LogsWithEfCore.Infra;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<UpdateLogs> UpdateLogs { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<User> Users { get; set; }

    public async Task GetAndSaveUpdateLogs<T>(long updateByUserId) where T : BaseEntity
    {
        var entry = ChangeTracker.Entries<T>()
            .FirstOrDefault(e => e.State == EntityState.Modified || e.State == EntityState.Added);

        List<UpdateLogs> logs = new();

        foreach (var property in entry.OriginalValues.Properties)
        {
            var updatedEntityId = entry.Property("Id").CurrentValue;
            var originalValue = entry.OriginalValues[property];
            var currentValue = entry.CurrentValues[property];

            if ((originalValue is "" && currentValue is null) || (originalValue is null && currentValue is ""))
                continue;

            if (!object.Equals(originalValue, currentValue))
            {
                var auditLog = new UpdateLogs
                {
                    TableName = entry.Entity.GetType().Name,
                    UpdatedEntityId = (long)updatedEntityId,
                    UpdateByUserId = updateByUserId,
                    Field = property.Name,
                    OldValue = originalValue?.ToString(),
                    NewValue = currentValue?.ToString()
                };

                logs.Add(auditLog);
            }
        }

        await UpdateLogs.AddRangeAsync(logs);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Name = "Usuario",
            Email = "usuario@email.com",
            Password = "123456",
            Active = true,
            CreatedAt = DateTime.Now
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSaving()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Active = true;
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdateAt = DateTime.Now;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.Active = false;
                    break;
            }
        }
    }
}
