using Application.Watchlists.Command.Create;
using Application.Watchlists.Command.Delete;
using Application.Watchlists.Command.MarkedWatch;
using Application.Watchlists.Query.Read;
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
    public async Task<IActionResult> AddToWatchlist([FromBody] CreateWatchListCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetWatchlist()
    {
        await _mediator.Send(new GetWatchListQuery());
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFromWatchList(DeleteWatchListCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> MarkAsWatched([FromBody] MarkedWatchlistCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}