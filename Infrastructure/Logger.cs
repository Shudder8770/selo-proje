namespace SmartCampus.Infrastructure;

public sealed class Logger
{
    private static readonly Lazy<Logger> _instance = new(() => new Logger());

    private Logger() { }

    public static Logger Instance => _instance.Value;

    public void Info(string message) => Console.WriteLine($"[INFO] {DateTime.UtcNow:HH:mm:ss} {message}");
}
