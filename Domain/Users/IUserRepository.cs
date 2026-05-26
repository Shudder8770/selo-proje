namespace SmartCampus.Domain.Users;

public interface IUserRepository
{
    void Add(User user);
    IReadOnlyCollection<User> GetAll();
}
