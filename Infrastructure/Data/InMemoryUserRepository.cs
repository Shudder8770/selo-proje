using SmartCampus.Domain.Users;

namespace SmartCampus.Infrastructure.Data;

public sealed class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = [];

    public void Add(User user) => _users.Add(user);

    public IReadOnlyCollection<User> GetAll() => _users.AsReadOnly();
}
