using SmartCampus.Domain.Announcements;

namespace SmartCampus.Application;

public static class AnnouncementFactory
{
    public static Announcement Create(AnnouncementType type, string title, string content) => type switch
    {
        AnnouncementType.Exam => new ExamAnnouncement(title, content),
        AnnouncementType.Event => new EventAnnouncement(title, content),
        AnnouncementType.FoodMenu => new FoodMenuAnnouncement(title, content),
        AnnouncementType.Library => new LibraryAnnouncement(title, content),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported announcement type")
    };
}
