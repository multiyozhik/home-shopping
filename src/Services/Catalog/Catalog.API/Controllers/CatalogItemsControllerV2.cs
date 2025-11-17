namespace Catalog.API.Controllers;

[ApiVersion("2")]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{version:apiVersion}/CatalogItems")]
public class CatalogItemsControllerV2: ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResultV2), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] {"CatalogItemsControllerV2"})]
    public async Task<ActionResult<GetCatalogItemsResultV2>> GetCatalogItems(
        [FromQuery] int pageIndex = 1, 
        [FromQuery] int pageSize = 5)
    {
        var query = new GetCatalogItemsQueryV2(pageIndex, pageSize);
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}
