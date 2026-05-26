using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Observers;
using SmartCampus.Domain.Users;
using SmartCampus.Infrastructure;

namespace SmartCampus.Application;

public sealed class StudentObserver : IAnnouncementObserver
{
    private readonly Student _student;

    public StudentObserver(Student student) => _student = student;

    public void Update(Announcement announcement)
    {
        Logger.Instance.Info($"Öğrenci bilgilendiriliyor: {_student.FullName}");
        foreach (var channel in _student.PreferredChannels)
        {
            var notifier = NotificationFactory.Create(channel);
            notifier.Send(_student.FullName, announcement.ToString());
        }
    }
}
