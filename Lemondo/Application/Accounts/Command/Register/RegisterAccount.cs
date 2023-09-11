using Application.Identity;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Accounts.Command.Register;

public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, Result>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterAccountCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = request.Username,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = request.Password
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return Result.Success();
        }
        else
        {
            var errors = result.Errors.Select(e => e.Description);
            return Result.Failure(errors);
        }
    }
}