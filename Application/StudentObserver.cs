using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Notifications;
using SmartCampus.Domain.Observers;
using SmartCampus.Domain.Users;
using SmartCampus.Infrastructure;

namespace SmartCampus.Application;

public sealed class StudentObserver : IAnnouncementObserver
{
    private readonly Student _student;
    private readonly INotificationFactory _notificationFactory;

    public StudentObserver(Student student, INotificationFactory notificationFactory)
    {
        _student = student;
        _notificationFactory = notificationFactory;
    }

    public void Update(Announcement announcement)
    {
        Logger.Instance.Info($"Öğrenci bilgilendiriliyor: {_student.FullName}");
        foreach (var channel in _student.PreferredChannels)
        {
            var notifier = _notificationFactory.Create(channel);
            notifier.Send(_student.FullName, announcement.ToString());
        }
    }
}
