using System.Domain.Entities;

namespace System.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string AccessToken,
    DateTime ExpiresIn
);