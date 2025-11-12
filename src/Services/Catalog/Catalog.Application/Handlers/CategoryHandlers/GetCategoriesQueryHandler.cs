namespace Catalog.Application.Handlers.CategoryHandlers;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery query, CancellationToken token)
    {
        var categoriesList = await categoryRepository.GetAllCategoriesAsync(token);
        var result = new GetCategoriesResult(categoriesList);
        return result;
    }
}
