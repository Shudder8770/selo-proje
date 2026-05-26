namespace SmartCampus.Domain.Notifications;

public interface INotification
{
    void Send(string recipient, string message);
}
