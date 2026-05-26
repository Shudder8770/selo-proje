using SmartCampus.Application;
using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Notifications;
using SmartCampus.Domain.Users;
using SmartCampus.Infrastructure;

namespace SmartCampus;

public static class Program
{
    public static void Main()
    {
        Logger.Instance.Info("Akıllı Kampüs Duyuru ve Bildirim Yönetim Sistemi başladı.");

        var publisher = new AnnouncementPublisher();

        var student1 = new Student("Ayşe Yılmaz", [NotificationChannel.Email, NotificationChannel.Push]);
        var student2 = new Student("Mehmet Demir", [NotificationChannel.Sms]);
        var teacher1 = new Teacher("Dr. Elif Kaya", [NotificationChannel.Email, NotificationChannel.Sms]);

        publisher.Subscribe(new UserAnnouncementObserver(student1));
        publisher.Subscribe(new UserAnnouncementObserver(student2));
        publisher.Subscribe(new UserAnnouncementObserver(teacher1));

        var examAnnouncement = AnnouncementFactory.Create(
            AnnouncementType.Exam,
            "Vize Tarihi Güncellemesi",
            "BIL3204 vize sınavı 3 Haziran 2026 saat 10:00'a alınmıştır.");

        publisher.Publish(examAnnouncement);
    }
}
