using SmartCampus.Domain.Announcements;

namespace SmartCampus.Domain.Observers;

public interface IAnnouncementObserver
{
    void Update(Announcement announcement);
}
