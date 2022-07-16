namespace System.Application.Services.Authentication;

public record AuthenticationResult(
    Guid Id,
    string UserName,
    string AccessToken,
    DateTime ExpiresIn
);