namespace Catalog.Infrastructure.Data.Seed;

public class InitializeDatabaseAsync : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (!await session.Query<Brand>().AnyAsync())
        {
            session.Store(InitialData.Brands);
        }

        if (!await session.Query<Category>().AnyAsync())
        {
            session.Store(InitialData.Categories);
        }
        
        if (!await session.Query<CatalogItem>().AnyAsync())
        {
            session.Store(InitialData.CatalogItems);
        }        

        await session.SaveChangesAsync(cancellation);
    }
}
