using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Observers;
using SmartCampus.Domain.Users;
using SmartCampus.Infrastructure;

namespace SmartCampus.Application;

public sealed class UserAnnouncementObserver : IAnnouncementObserver
{
    private readonly User _user;

    public UserAnnouncementObserver(User user) => _user = user;

    public void Update(Announcement announcement)
    {
        Logger.Instance.Info($"{GetUserLabel(_user.Type)} bilgilendiriliyor: {_user.FullName}");
        foreach (var channel in _user.PreferredChannels)
        {
            var notifier = NotificationFactory.Create(channel);
            notifier.Send(_user.FullName, announcement.ToString());
        }
    }

    private static string GetUserLabel(UserType userType) => userType switch
    {
        UserType.Student => "Öğrenci",
        UserType.Teacher => "Öğretmen",
        _ => "Kullanıcı"
    };
}
