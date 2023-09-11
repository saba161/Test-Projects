using Application.Blogs.Commands.Create;
using Application.Blogs.Commands.Delete;
using Application.Blogs.Commands.Update;
using Application.Blogs.Queries.GetById;
using Application.Blogs.Queries.Search;
using Domain.Exception.Blog;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<BlogController> _logger;

    public BlogController(IMediator mediator, ILogger<BlogController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetBlogById([FromRoute] GetBlogQuery query)
    {
        try
        {
            var result = await _mediator.Send(query);
            if (result == null)
            {
                throw new BlogNotFoundException(query.Id);
            }

            return Ok(result);
        }
        catch (BlogNotFoundException)
        {
            _logger.LogError("Blog not found.");
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        catch (ValidationException e)
        {
            _logger.LogError(e.Message);
            return BadRequest();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        try
        {
            var command = new DeleteBlogCommand(id);
            await _mediator.Send(command);

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest();
        }
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetAllBlogs([FromQuery] SearchBlogQuery query)
    {
        try
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest();
        }
    }
}