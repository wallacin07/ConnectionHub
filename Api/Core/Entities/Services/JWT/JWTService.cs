using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Api.Domain.Services;
using Api.Domain.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Core.Services;
public class JwtService : IJwtService
{
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly SymmetricSecurityKey _securityKey;
    private readonly SigningCredentials _credentials;
    private readonly UserContext _userContext;

    public JwtService(
        JwtSecurityTokenHandler tokenHandler,
        UserContext userContext,
        JwtSettings settings)
    {
        _tokenHandler = tokenHandler;
        _userContext = userContext;

        _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));
        _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512);
    }

    public OutboundToken GenerateToken(UserInfoDTO user)
    {
        var claims = new List<Claim>
        {
            new("User_Id", user.Id.ToString()),
            new("Name", user.Name)
        };

        var secToken = new JwtSecurityToken(
            issuer: "ConnectionHub",
            audience: null,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: _credentials);

        var token = _tokenHandler.WriteToken(secToken);

        return new OutboundToken(token);
    }

    public void ValidateToken(string jwt)
    {
        ClaimsPrincipal claims;

        try
        {
            claims = _tokenHandler.ValidateToken(jwt,
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidIssuer = "ConnectionHub",
                    IssuerSigningKey = _securityKey
                },
                out _);
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to validate token and its claims.", ex);
        }

        _userContext.Fill(new ContextData
        {
            UserId = int.Parse(claims.FindFirst("User_Id")!.Value),
            Username = claims.FindFirst("Name")!.Value,
        });
    }
}
