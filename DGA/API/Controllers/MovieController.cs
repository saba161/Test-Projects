using Application.Movies.Commands.CreateMovie;
using Application.Movies.Commands.DeleteMovie;
using Application.Movies.Commands.UpdateMovie;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovieCommand command)
    {
        var movieId = await _mediator.Send(command);
        return Ok(new { MoviedId = movieId });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteMovieCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateMovieCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}