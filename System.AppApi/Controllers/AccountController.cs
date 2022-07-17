using System.AppContracts.AppContracts;
using System.Application.Services.Authentication;

using Microsoft.AspNetCore.Mvc;

namespace System.AppApi.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IAuthenticationService _service;

    public AccountController(IAuthenticationService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _service.Register(request.UserName, request.Mima);
        var response = new AuthenticationResponse(
            Id: result.user.Id,
            UserName: result.user.UserName,
            AccessToken: result.AccessToken,
            ExpiresIn: result.ExpiresIn
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _service.Login(request.UserName, request.Mima);
        var response = new AuthenticationResponse(
            Id: result.user.Id,
            UserName: result.user.UserName,
            AccessToken: result.AccessToken,
            ExpiresIn: result.ExpiresIn
        );
        return Ok(response);
    }
}