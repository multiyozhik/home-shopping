namespace Catalog.API.Controllers;

public class CategoriesController(IMediator mediator) : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCategoriesResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCategoriesResult>> GetCategory()
    {
        var result = await mediator.Send(new GetCategoriesQuery());
        return Ok(result);
    }
}
