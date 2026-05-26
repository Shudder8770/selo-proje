namespace SmartCampus.Domain.Announcements;

public sealed class FoodMenuAnnouncement : Announcement
{
    public FoodMenuAnnouncement(string title, string content) : base(title, content) { }
    public override AnnouncementType Type => AnnouncementType.FoodMenu;
}
