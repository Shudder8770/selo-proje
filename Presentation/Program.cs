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
        INotificationFactory notificationFactory = new NotificationFactory();

        var student1 = new Student("Ayşe Yılmaz", [NotificationChannel.Email, NotificationChannel.Push]);
        var student2 = new Student("Mehmet Demir", [NotificationChannel.Sms]);
        var teacher1 = new Teacher("Dr. Elif Kaya", [NotificationChannel.Email, NotificationChannel.Sms]);

        publisher.Subscribe(new StudentObserver(student1, notificationFactory));
        publisher.Subscribe(new StudentObserver(student2, notificationFactory));
        publisher.Subscribe(new TeacherObserver(teacher1, notificationFactory));

        var examAnnouncement = AnnouncementFactory.Create(
            AnnouncementType.Exam,
            "Vize Tarihi Güncellemesi",
            "BIL3204 vize sınavı 3 Haziran 2026 saat 10:00'a alınmıştır.");

        publisher.Publish(examAnnouncement);
    }
}
