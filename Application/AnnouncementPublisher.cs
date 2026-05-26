using SmartCampus.Domain.Announcements;
using SmartCampus.Domain.Observers;
using SmartCampus.Infrastructure;

namespace SmartCampus.Application;

public sealed class AnnouncementPublisher
{
    private readonly List<IAnnouncementObserver> _observers = [];

    public void Subscribe(IAnnouncementObserver observer) => _observers.Add(observer);

    public void Publish(Announcement announcement)
    {
        Logger.Instance.Info($"Yeni duyuru yayınlandı: {announcement}");
        foreach (var observer in _observers)
        {
            observer.Update(announcement);
        }
    }
}
