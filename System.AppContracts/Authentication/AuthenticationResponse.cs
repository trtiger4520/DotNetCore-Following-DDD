namespace System.AppContracts.AppContracts;

public record AuthenticationResponse(
    Guid Id,
    string UserName,
    string AccessToken,
    DateTime ExpiresIn
);