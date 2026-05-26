namespace SmartCampus.Domain.Announcements;

public sealed class ExamAnnouncement : Announcement
{
    public ExamAnnouncement(string title, string content) : base(title, content) { }
    public override AnnouncementType Type => AnnouncementType.Exam;
}
