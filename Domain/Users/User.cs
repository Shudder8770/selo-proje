using SmartCampus.Domain.Notifications;

namespace SmartCampus.Domain.Users;

public abstract class User
{
    protected User(string fullName, UserType type, IReadOnlyCollection<NotificationChannel> channels)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Type = type;
        PreferredChannels = channels;
    }

    public Guid Id { get; }
    public string FullName { get; }
    public UserType Type { get; }
    public IReadOnlyCollection<NotificationChannel> PreferredChannels { get; }
}
