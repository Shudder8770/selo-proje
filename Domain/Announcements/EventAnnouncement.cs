namespace SmartCampus.Domain.Announcements;

public sealed class EventAnnouncement : Announcement
{
    public EventAnnouncement(string title, string content) : base(title, content) { }
    public override AnnouncementType Type => AnnouncementType.Event;
}
