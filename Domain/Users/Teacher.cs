using SmartCampus.Domain.Notifications;

namespace SmartCampus.Domain.Users;

public sealed class Teacher : User
{
    public Teacher(string fullName, IReadOnlyCollection<NotificationChannel> channels)
        : base(fullName, UserType.Teacher, channels) { }
}
