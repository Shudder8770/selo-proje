namespace SmartCampus.Domain.Announcements;

public sealed class LibraryAnnouncement : Announcement
{
    public LibraryAnnouncement(string title, string content) : base(title, content) { }
    public override AnnouncementType Type => AnnouncementType.Library;
}
