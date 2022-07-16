namespace System.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string userName, string mima);
    AuthenticationResult Login(string userName, string mima);
}