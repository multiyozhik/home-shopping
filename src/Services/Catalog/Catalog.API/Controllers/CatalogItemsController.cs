namespace Catalog.API.Controllers;

public class CatalogItemsController(IMediator mediator) : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResult>> GetCatalogItems()
    {
        var result = await mediator.Send(new GetCatalogItemsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetCatalogItemByIdResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemByIdResult>> GetCatalogItemById(Guid id)
    {
        var result = await mediator.Send(new GetCatalogItemByIdQuery(id));
        return Ok(result);
    }

    [HttpGet("title/{catalogItemTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemsByTitleResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsByTitleResult>> GetByTitle(string catalogItemTitle)
    {
        var result = await mediator.Send(new GetCatalogItemsByTitleQuery(catalogItemTitle));
        return Ok(result);
    }

    [HttpGet("brand/{brandTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemsByBrandTitleResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsByBrandTitleResult>> GetByBrandTitle(string brandTitle)
    {
        var result = await mediator.Send(new GetCatalogItemsByBrandTitleQuery(brandTitle));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateCatalogItemResult), (int)HttpStatusCode.Created)]
    public async Task<ActionResult<CreateCatalogItemResult>> CreateCatalogItem(
        [FromBody]CreateCatalogItemDto createCatalogItemDto)
    {
        var createCatalogItemModel = createCatalogItemDto.Adapt<CreateCatalogItemModel>();
        var result = await mediator.Send(new CreateCatalogItemCommand(createCatalogItemModel));
        return CreatedAtAction(nameof(CreateCatalogItem), new {id = result.Id}, result);
    }
}
