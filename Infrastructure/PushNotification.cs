using SmartCampus.Domain.Notifications;

namespace SmartCampus.Infrastructure;

public sealed class PushNotification : INotification
{
    public void Send(string recipient, string message) =>
        Console.WriteLine($"[PUSH] To: {recipient} | Message: {message}");
}
