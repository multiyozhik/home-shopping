namespace Checkout.Infrastructure.Data.Configurations;

/// <summary> Контекст для сущности заказа </summary>
public class OrderContext(DbContextOptions<OrderContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        HandleAuditFields();
        return base.SaveChangesAsync(token);
    }

    public override int SaveChanges()
    {
        HandleAuditFields();
        return base.SaveChanges();
    }

    /// <summary> Метод для установки в CreatedBy / LastModifiedBy фиктивного пользователя (для простоты) перед сохранением изменений </summary>
    private void HandleAuditFields()
    {
        var currentUser = $"User {Guid.NewGuid().ToString().Substring(0, 5)}";
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var item in entries)
        {
            switch (item.State)
            {
                case EntityState.Added:
                    item.Entity.SetCreatedAudit(currentUser);
                    break;
                case EntityState.Modified:
                    item.Entity.SetModifiedAudit(currentUser);
                    break;
            }
        }
    }
}
