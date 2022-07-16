namespace System.AppContracts.AppContracts;

public record AuthenticationRequest(
    Guid Id,
    string UserName,
    string AccessToken,
    DateTime ExpiresIn
);