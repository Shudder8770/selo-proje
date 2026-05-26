using SmartCampus.Domain.Notifications;

namespace SmartCampus.Infrastructure;

public sealed class SmsNotification : INotification
{
    public void Send(string recipient, string message) =>
        Console.WriteLine($"[SMS] To: {recipient} | Message: {message}");
}
