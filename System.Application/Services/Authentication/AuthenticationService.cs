using System.Application.Common.Interfaces.Authentication;
using System.Application.Common.Interfaces.Persistence;
using System.Application.Common.Interfaces.Services;
using System.Domain.Entities;

namespace System.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator, IDateTimeProvider dateTimeProvider, IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _dateTimeProvider = dateTimeProvider;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string userName, string mima)
    {
        if (_userRepository.GetUserByUserName(userName) is not User user)
        {
            throw new Exception("使用者不存在");
        }

        if (user.Mima != mima)
        {
            throw new Exception("密碼錯誤");
        }

        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token, DateTime.Now.AddDays(7));
    }

    public AuthenticationResult Register(string userName, string mima)
    {
        if (_userRepository.GetUserByUserName(userName) is not null)
        {
            throw new Exception("使用者已存在");
        }

        var user = new User
        {
            UserName = userName,
            Mima = mima,
            CreateTime = _dateTimeProvider.Now,
        };

        _userRepository.AddUser(user);

        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token, _dateTimeProvider.UtcNow.AddDays(7));
    }
}