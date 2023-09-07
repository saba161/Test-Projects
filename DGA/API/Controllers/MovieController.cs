using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Movies.Commands.Create;
using Application.Movies.Commands.Delete;
using Application.Movies.Commands.Update;
using Application.Movies.Queries.GetMovie;
using Application.Movies.Queries.Read;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieCommand command)
        {
            var movieId = await _mediator.Send(command);
            return Ok(new { MovieId = movieId });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMovieCommand(id);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMovieCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetMovieQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}