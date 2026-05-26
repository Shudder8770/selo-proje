namespace SmartCampus.Domain.Announcements;

public abstract class Announcement
{
    protected Announcement(string title, string content)
    {
        Title = title;
        Content = content;
        PublishedAt = DateTime.UtcNow;
    }

    public string Title { get; }
    public string Content { get; }
    public DateTime PublishedAt { get; }

    public abstract AnnouncementType Type { get; }

    public override string ToString() =>
        $"[{Type}] {Title} - {Content} ({PublishedAt:yyyy-MM-dd HH:mm:ss} UTC)";
}
