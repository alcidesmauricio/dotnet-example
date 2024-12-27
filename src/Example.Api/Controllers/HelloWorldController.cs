using Example.Application.CreateHelloWorld;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Example.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly IMediator _mediator;

    public HelloWorldController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(CreateHelloWorldResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateHelloWorldCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}