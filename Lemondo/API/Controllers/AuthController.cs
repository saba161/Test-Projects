using Application.Accounts.Command.Login;
using Application.Accounts.Command.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<BlogController> _logger;

    public AuthController(IMediator mediator, ILogger<BlogController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [Route("registeration")]
    public async Task<IActionResult> Register(RegisterAccountCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginAccountCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}