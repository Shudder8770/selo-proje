using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Observers;
using SmartCampus.Domain.Users;
using SmartCampus.Infrastructure;

namespace SmartCampus.Application;

public sealed class TeacherObserver : IAnnouncementObserver
{
    private readonly Teacher _teacher;

    public TeacherObserver(Teacher teacher) => _teacher = teacher;

    public void Update(Announcement announcement)
    {
        Logger.Instance.Info($"Öğretmen bilgilendiriliyor: {_teacher.FullName}");
        foreach (var channel in _teacher.PreferredChannels)
        {
            var notifier = NotificationFactory.Create(channel);
            notifier.Send(_teacher.FullName, announcement.ToString());
        }
    }
}
