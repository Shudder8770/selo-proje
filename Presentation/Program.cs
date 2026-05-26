using SmartCampus.Application;
using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Notifications;
using SmartCampus.Domain.Users;
using SmartCampus.Infrastructure;
using SmartCampus.Infrastructure.Repositories;

namespace SmartCampus;

public static class Program
{
    public static void Main()
    {
        Logger.Instance.Info("Akıllı Kampüs Duyuru ve Bildirim Yönetim Sistemi başladı.");

        var userRepository = new InMemoryUserRepository();
        var announcementRepository = new InMemoryAnnouncementRepository();

        var userService = new UserService(userRepository);
        var announcementService = new AnnouncementService(announcementRepository, new AnnouncementPublisher());

        publisher.Subscribe(new UserAnnouncementObserver(student1));
        publisher.Subscribe(new UserAnnouncementObserver(student2));
        publisher.Subscribe(new UserAnnouncementObserver(teacher1));

        var examAnnouncement = AnnouncementFactory.Create(
            AnnouncementType.Exam,
            "Vize Tarihi Güncellemesi",
            "BIL3204 vize sınavı 3 Haziran 2026 saat 10:00'a alınmıştır.");

        announcementService.Publish(examAnnouncement);

        Logger.Instance.Info("Kayıtlı kullanıcılar:");
        foreach (var user in userService.ListUsers())
        {
            Logger.Instance.Info($"- {user.Type}: {user.FullName}");
        }

        Logger.Instance.Info("Duyuru geçmişi:");
        foreach (var announcement in announcementService.GetAnnouncementHistory())
        {
            Logger.Instance.Info($"- {announcement}");
        }
    }
}
