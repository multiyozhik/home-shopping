namespace Catalog.API.Controllers;

public class BrandsController(IMediator mediator) : ApiController
{
    [HttpGet]
    public async Task<ActionResult<GetBrandsResult>> GetBrand()
    {
        var result = await mediator.Send(new GetBrandsQuery());
        return Ok(result);
    }
}
