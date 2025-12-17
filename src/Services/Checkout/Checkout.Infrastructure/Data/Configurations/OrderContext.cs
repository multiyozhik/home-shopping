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
}
