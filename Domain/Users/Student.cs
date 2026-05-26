using SmartCampus.Domain.Notifications;

namespace SmartCampus.Domain.Users;

public sealed class Student : User
{
    public Student(string fullName, IReadOnlyCollection<NotificationChannel> channels)
        : base(fullName, UserType.Student, channels) { }
}
