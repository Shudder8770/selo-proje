using SmartCampus.Domain.Notifications;

namespace SmartCampus.Infrastructure;

public sealed class EmailNotification : INotification
{
    public void Send(string recipient, string message) =>
        Console.WriteLine($"[EMAIL] To: {recipient} | Message: {message}");
}
