namespace SmartCampus.Domain.Notifications;

public interface INotificationFactory
{
    INotification Create(NotificationChannel channel);
}
