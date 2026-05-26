using SmartCampus.Domain.Notifications;

namespace SmartCampus.Infrastructure;

public sealed class NotificationFactory : INotificationFactory
{
    public INotification Create(NotificationChannel channel) => channel switch
    {
        NotificationChannel.Email => new EmailNotification(),
        NotificationChannel.Sms => new SmsNotification(),
        NotificationChannel.Push => new PushNotification(),
        _ => throw new ArgumentOutOfRangeException(nameof(channel), channel, "Unsupported notification channel")
    };
}
