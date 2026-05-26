# BIL3204 Final Ödevi - Akıllı Kampüs Duyuru ve Bildirim Yönetim Sistemi

Bu proje C# ile katmanlı mimaride geliştirilmiştir.

## Kullanılan Tasarım Desenleri
- **Observer Pattern**: `AnnouncementPublisher`, `IAnnouncementObserver`, `StudentObserver`, `TeacherObserver`
- **Factory Pattern**: `AnnouncementFactory`, `NotificationFactory`
- **Singleton Pattern**: `Logger`

## Katmanlar
- **Presentation Layer**: `Presentation/Program.cs`
- **Application Layer**: yayınlama akışı, factoryler, observer implementasyonları, servisler
- **Domain Layer**: varlıklar, enumlar, interface/abstract sınıflar
- **Infrastructure Layer**: bildirim sağlayıcıları, logger, in-memory veri yönetimi

## Senaryo
1. Sisteme öğrenci ve öğretmen kullanıcıları eklenir.
2. Kullanıcıların bildirim tercihleri tanımlanır.
3. Factory ile duyurular üretilir.
4. Duyurular yayınlanır.
5. Observer yapısı ile kullanıcılar bilgilendirilir.
6. Notification factory ile ilgili kanalda bildirim konsola yazdırılır.

## Not
Çalıştırma için `dotnet` CLI gereklidir.
