using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WatchListController : ControllerBase
{
    private readonly IMediator _mediator;

    public WatchListController(IMediator mediator)
    {
        _mediator = mediator;
    }
}