namespace SmartCampus.Domain.Announcements;

public interface IAnnouncementRepository
{
    void Add(Announcement announcement);
    IReadOnlyCollection<Announcement> GetAll();
}
