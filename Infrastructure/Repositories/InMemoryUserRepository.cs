using SmartCampus.Domain.Users;

namespace SmartCampus.Infrastructure.Repositories;

public sealed class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = [];

    public void Add(User user) => _users.Add(user);

    public User? GetById(Guid id) => _users.FirstOrDefault(user => user.Id == id);

    public IReadOnlyCollection<User> GetAll() => _users.AsReadOnly();
}
