using SmartCampus.Application;
using SmartCampus.Application.Services;
using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Notifications;
using SmartCampus.Domain.Users;
using SmartCampus.Infrastructure;
using SmartCampus.Infrastructure.Data;

namespace SmartCampus;

public static class Program
{
    public static void Main()
    {
        Logger.Instance.Info("Akıllı Kampüs Duyuru ve Bildirim Yönetim Sistemi başladı.");

        var publisher = new AnnouncementPublisher();
        var userRepository = new InMemoryUserRepository();
        var announcementRepository = new InMemoryAnnouncementRepository();
        var service = new CampusAnnouncementService(publisher, announcementRepository, userRepository);

        var student1 = new Student("Ayşe Yılmaz", [NotificationChannel.Email, NotificationChannel.Push]);
        var student2 = new Student("Mehmet Demir", [NotificationChannel.Sms]);
        var teacher1 = new Teacher("Dr. Elif Kaya", [NotificationChannel.Email, NotificationChannel.Sms]);

        service.RegisterUser(student1, new StudentObserver(student1));
        service.RegisterUser(student2, new StudentObserver(student2));
        service.RegisterUser(teacher1, new TeacherObserver(teacher1));

        var examAnnouncement = AnnouncementFactory.Create(
            AnnouncementType.Exam,
            "Vize Tarihi Güncellemesi",
            "BIL3204 vize sınavı 3 Haziran 2026 saat 10:00'a alınmıştır.");

        var eventAnnouncement = AnnouncementFactory.Create(
            AnnouncementType.Event,
            "Yapay Zeka Semineri",
            "Yapay Zeka semineri 5 Haziran 2026 saat 14:00'te konferans salonunda yapılacaktır.");

        service.PublishAnnouncement(examAnnouncement);
        service.PublishAnnouncement(eventAnnouncement);

        Logger.Instance.Info($"Kayıtlı kullanıcı sayısı: {service.GetRegisteredUsers().Count}");
        Logger.Instance.Info($"Yayınlanan duyuru sayısı: {service.GetAnnouncementHistory().Count}");
    }
}
