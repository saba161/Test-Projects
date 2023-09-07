using Application.Watchlists.Command.Create;
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

    [HttpPost]
    public async Task<IActionResult> AddToWatchlist(CreateWatchListCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetWatchlist(int userId)
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> MarkAsWatched(int userId, int movieId)
    {
        return Ok();
    }
}