using System.Application.Common.Interfaces.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace System.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(Guid Id, string userName, DateTime? expires = null)
    {
        var secret = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(secret),
            SecurityAlgorithms.HmacSha512
        );

        Claim[] claims = new[] {
            new Claim(JwtRegisteredClaimNames.UniqueName, Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, userName),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            signingCredentials: signingCredentials,
            claims: claims,
            expires: expires ?? _dateTimeProvider.UtcNow.AddDays(_jwtSettings.ExpiryDays));

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}