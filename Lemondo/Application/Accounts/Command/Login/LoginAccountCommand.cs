using Application.Models;
using MediatR;

namespace Application.Accounts.Command.Login;

public class LoginAccountCommand : IRequest<LoginAccountCommandResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}