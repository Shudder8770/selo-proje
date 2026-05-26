namespace SmartCampus.Domain.Users;

public interface IUserRepository
{
    void Add(User user);
    User? GetById(Guid id);
    IReadOnlyCollection<User> GetAll();
}
