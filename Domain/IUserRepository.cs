using Project.Application.Contacts;

namespace Project.domain;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
}