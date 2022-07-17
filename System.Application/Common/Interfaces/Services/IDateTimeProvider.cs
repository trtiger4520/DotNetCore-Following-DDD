namespace System.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    /// <summary>
    /// 取得 server 的本地時間
    /// </summary>
    /// <value></value>
    DateTime Now { get; }
    /// <summary>
    /// 取得 UTC 時間
    /// </summary>
    /// <value></value>
    DateTime UtcNow { get; }
}