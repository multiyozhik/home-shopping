namespace Checkout.Infrastructure.Repositories;

/// <summary> Абстрактный класс репозитория сущностей </summary>
public abstract class BaseRepository<T>(DbContext dbContext): IRepository<T>
    where T : class, IAggregateRoot
{    
    /// <inheritdoc/>
    public virtual async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }
    
    /// <inheritdoc/>
    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<T>()
            .FirstOrDefaultAsync<T>(e => EF.Property<Guid>(e, "Id") == id);
    }
    
    /// <inheritdoc/>
    public virtual async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await dbContext.Set<T>().Where(predicate).ToListAsync();
    }

    /// <inheritdoc/>
    public virtual async Task AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public virtual async Task<bool> UpdateAsync(T entity)
    {
        dbContext.Set<T>().Update(entity);
        return await dbContext.SaveChangesAsync() > 0;
    }

    /// <inheritdoc/>
    public virtual async Task<bool> DeleteAsync(T entity)
    {
        dbContext.Set<T>().Remove(entity);
        return await dbContext.SaveChangesAsync() > 0;
    }
}