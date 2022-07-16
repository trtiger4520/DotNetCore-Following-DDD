namespace System.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid Id, string userName, DateTime? expires = null);
}