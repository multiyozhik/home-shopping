namespace Catalog.API.Controllers;

public class CatalogItemController(IMediator mediator) : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResult>> GetCategoryItems()
    {
        var result = await mediator.Send(new GetCatalogItemsQuery());
        return Ok(result);
    }
}
