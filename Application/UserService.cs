using SmartCampus.Domain.Users;

namespace SmartCampus.Application;

public sealed class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) => _userRepository = userRepository;

    public void AddUser(User user) => _userRepository.Add(user);

    public User? GetUser(Guid id) => _userRepository.GetById(id);

    public IReadOnlyCollection<User> ListUsers() => _userRepository.GetAll();
}
