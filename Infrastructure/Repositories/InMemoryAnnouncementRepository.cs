using SmartCampus.Domain.Announcements;

namespace SmartCampus.Infrastructure.Repositories;

public sealed class InMemoryAnnouncementRepository : IAnnouncementRepository
{
    private readonly List<Announcement> _announcements = [];

    public void Add(Announcement announcement) => _announcements.Add(announcement);

    public IReadOnlyCollection<Announcement> GetAll() => _announcements.AsReadOnly();
}
