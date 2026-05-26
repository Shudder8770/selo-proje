using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Users;
using SmartCampus.Infrastructure;

namespace SmartCampus.Application;

public sealed class AnnouncementService
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly AnnouncementPublisher _publisher;

    public AnnouncementService(IAnnouncementRepository announcementRepository, AnnouncementPublisher publisher)
    {
        _announcementRepository = announcementRepository;
        _publisher = publisher;
    }

    public void Subscribe(User user)
    {
        switch (user)
        {
            case Student student:
                _publisher.Subscribe(new StudentObserver(student));
                break;
            case Teacher teacher:
                _publisher.Subscribe(new TeacherObserver(teacher));
                break;
            default:
                Logger.Instance.Error($"Desteklenmeyen kullanıcı tipi: {user.Type}");
                break;
        }
    }

    public void Publish(Announcement announcement)
    {
        _announcementRepository.Add(announcement);
        _publisher.Publish(announcement);
    }

    public IReadOnlyCollection<Announcement> GetAnnouncementHistory() => _announcementRepository.GetAll();
}
