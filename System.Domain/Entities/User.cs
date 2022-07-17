namespace System.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; } = null!;
    public string Mima { get; set; } = null!;
    public DateTime CreateTime { get; set; }
}