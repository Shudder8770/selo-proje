using SmartCampus.Domain.Notifications;
using SmartCampus.Infrastructure;

namespace SmartCampus.Application;

public static class NotificationFactory
{
    public static INotification Create(NotificationChannel channel) => channel switch
    {
        NotificationChannel.Email => new EmailNotification(),
        NotificationChannel.Sms => new SmsNotification(),
        NotificationChannel.Push => new PushNotification(),
        _ => throw new ArgumentOutOfRangeException(nameof(channel), channel, "Unsupported notification channel")
    };
}
