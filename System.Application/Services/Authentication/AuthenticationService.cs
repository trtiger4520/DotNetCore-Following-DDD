using System.Application.Common.Interfaces.Authentication;
using System.Application.Common.Interfaces.Services;

namespace System.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator, IDateTimeProvider dateTimeProvider)
    {
        _tokenGenerator = tokenGenerator;
        _dateTimeProvider = dateTimeProvider;
    }

    public AuthenticationResult Login(string userName, string mima)
    {
        var id = Guid.NewGuid();

        var token = _tokenGenerator.GenerateToken(id, userName);

        return new AuthenticationResult(id, userName, token, DateTime.Now.AddDays(7));
    }

    public AuthenticationResult Register(string userName, string mima)
    {
        // TODO 確認使用者是否存在

        // TODO 建立使用者

        var id = Guid.NewGuid();

        var token = _tokenGenerator.GenerateToken(id, userName);

        return new AuthenticationResult(id, userName, token, _dateTimeProvider.UtcNow.AddDays(7));
    }
}