using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Identity;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Accounts.Command.Login;

public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, LoginAccountCommandResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly IConfiguration _configuration;


    public LoginAccountCommandHandler(UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService, IConfiguration configuration)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _configuration = configuration;
    }

    public async Task<LoginAccountCommandResponse> Handle(LoginAccountCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        await _userManager.CheckPasswordAsync(user, request.Password);
        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        string token = GenerateToken(authClaims);
        return new LoginAccountCommandResponse { Token = token };
    }

    private string GenerateToken(IEnumerable<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
        var _TokenExpiryTimeInHour = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeInHour"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration["JWTKey:ValidIssuer"],
            Audience = _configuration["JWTKey:ValidAudience"],
            //Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
            Expires = DateTime.UtcNow.AddMinutes(1),
            SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}