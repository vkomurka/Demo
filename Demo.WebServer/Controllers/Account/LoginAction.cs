using Demo.Contracts.Dtos;
using Demo.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Demo.WebServer.Controllers.Account;

public class LoginAction : IAction
{
    public LoginAction(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public UserManager<IdentityUser> UserManager { get; }
    public IConfiguration Configuration { get; }

    public async Task<AuthResponseDto> ExecuteAsync(UserDto userDto)
    {
        var user = await UserManager.FindByEmailAsync(userDto.Email);
        var isValidUser = await UserManager.CheckPasswordAsync(user, userDto.Password);

        if (user == null || !isValidUser)
        {
            return null;
        }

        var token = await GenerateToken(user);
        var response = new AuthResponseDto
        {
            Token = token,
            UserId = user.Id,
        };
        return response;
    }

    private async Task<string> GenerateToken(IdentityUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var roles = await UserManager.GetRolesAsync(user);
        var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
        var userClaims = await UserManager.GetClaimsAsync(user);

        var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new("uid", user.Id),
            }
        .Union(userClaims)
        .Union(roleClaims);

        var token = new JwtSecurityToken(
            issuer: Configuration["JwtSettings:Issuer"],
            audience: Configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToInt32(Configuration["JwtSettings:DurationInMinutes"])),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
