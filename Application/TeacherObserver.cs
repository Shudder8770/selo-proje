using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Notifications;
using SmartCampus.Domain.Observers;
using SmartCampus.Domain.Users;
using SmartCampus.Infrastructure;

namespace SmartCampus.Application;

public sealed class TeacherObserver : IAnnouncementObserver
{
    private readonly Teacher _teacher;
    private readonly INotificationFactory _notificationFactory;

    public TeacherObserver(Teacher teacher, INotificationFactory notificationFactory)
    {
        _teacher = teacher;
        _notificationFactory = notificationFactory;
    }

    public void Update(Announcement announcement)
    {
        Logger.Instance.Info($"Öğretmen bilgilendiriliyor: {_teacher.FullName}");
        foreach (var channel in _teacher.PreferredChannels)
        {
            var notifier = _notificationFactory.Create(channel);
            notifier.Send(_teacher.FullName, announcement.ToString());
        }
    }
}
