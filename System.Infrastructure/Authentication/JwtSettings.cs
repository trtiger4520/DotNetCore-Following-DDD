namespace System.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = nameof(JwtSettings);
    public string Secret { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public int ExpiryDays { get; init; }
    public string Audience { get; init; } = null!;
}