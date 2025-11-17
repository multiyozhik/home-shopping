namespace Catalog.API.Controllers;

public class CatalogItemsController : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResult>> GetCatalogItems()
    {
        var result = await Mediator.Send(new GetCatalogItemsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetCatalogItemByIdResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemByIdResult>> GetCatalogItemById(Guid id)
    {
        var result = await Mediator.Send(new GetCatalogItemByIdQuery(id));
        return Ok(result);
    }

    [HttpGet("title/{catalogItemTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemsByTitleResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsByTitleResult>> GetByTitle(string catalogItemTitle)
    {
        var result = await Mediator.Send(new GetCatalogItemsByTitleQuery(catalogItemTitle));
        return Ok(result);
    }

    [HttpGet("brand/{brandTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemsByBrandTitleResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsByBrandTitleResult>> GetByBrandTitle(string brandTitle)
    {
        var result = await Mediator.Send(new GetCatalogItemsByBrandTitleQuery(brandTitle));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateCatalogItemResult), (int)HttpStatusCode.Created)]
    public async Task<ActionResult<CreateCatalogItemResult>> CreateCatalogItem(
        [FromBody] CreateCatalogItemDto createCatalogItemDto)
    {
        var createCatalogItemModel = createCatalogItemDto.Adapt<CreateCatalogItemModel>();
        var result = await Mediator.Send(new CreateCatalogItemCommand(createCatalogItemModel));
        return CreatedAtAction(nameof(CreateCatalogItem), new {id = result.Id}, result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdateCatalogItemResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateCatalogItemResult>> UpdateCatalogItem(
        [FromBody] UpdateCatalogItemDto updateCatalogItemDto)
    {
        var updateCatalogItemModel = updateCatalogItemDto.Adapt<UpdateCatalogItemModel>();
        var result = await Mediator.Send(new UpdateCatalogItemCommand(updateCatalogItemModel));
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(DeleteCatalogItemByIdResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteCatalogItemByIdResult>> DeleteCatalogItemById(Guid id)
    {
        var result = await Mediator.Send(new DeleteCatalogItemByIdCommand(id));
        return Ok(result);
    }
}
