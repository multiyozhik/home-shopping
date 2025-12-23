namespace Checkout.Infrastructure.Repositories;

/// <summary> Репозиторий заказов </summary>
public class OrderRepository(OrderContext context) 
    : BaseRepository<Order>(context), IOrderRepository
{
    /// <inheritdoc/>
    public async Task<IEnumerable<Order>> GetOrdersByAccountName(string accountName, CancellationToken token)
    {
        return await dbContext.Set<Order>()
            .Include(o => o.Items)
            .AsNoTracking()
            .Where(o => o.AccountName == accountName)
            .ToListAsync();
    }

    /// <inheritdoc/>
    public override async Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken token)
    {
        return await dbContext.Set<Order>()
            .Include(o => o.Items)
            .AsNoTracking()
            .ToListAsync();
    }
    
    /// <inheritdoc/>
    public override async Task<Order?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await dbContext.Set<Order>()
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    /// <inheritdoc/>
    public override async Task<IReadOnlyList<Order>> FindAsync(Expression<Func<Order, bool>> predicate, CancellationToken token)
    {
        return await dbContext.Set<Order>()
            .Include(o => o.Items)
            .Where(predicate).ToListAsync();
    }
}