using System.ComponentModel.DataAnnotations;
using Application.Models;
using MediatR;

namespace Application.Accounts.Command.Register;

public class RegisterAccountCommand : IRequest<Result>
{
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string FirstName { get; set; }

    public string LastName { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}