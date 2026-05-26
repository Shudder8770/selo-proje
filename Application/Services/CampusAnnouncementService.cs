using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Observers;
using SmartCampus.Domain.Users;

namespace SmartCampus.Application.Services;

public sealed class CampusAnnouncementService
{
    private readonly AnnouncementPublisher _publisher;
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IUserRepository _userRepository;

    public CampusAnnouncementService(
        AnnouncementPublisher publisher,
        IAnnouncementRepository announcementRepository,
        IUserRepository userRepository)
    {
        _publisher = publisher;
        _announcementRepository = announcementRepository;
        _userRepository = userRepository;
    }

    public void RegisterUser(User user, IAnnouncementObserver observer)
    {
        _userRepository.Add(user);
        _publisher.Subscribe(observer);
    }

    public void PublishAnnouncement(Announcement announcement)
    {
        _announcementRepository.Add(announcement);
        _publisher.Publish(announcement);
    }

    public IReadOnlyCollection<User> GetRegisteredUsers() => _userRepository.GetAll();
    public IReadOnlyCollection<Announcement> GetAnnouncementHistory() => _announcementRepository.GetAll();
}
