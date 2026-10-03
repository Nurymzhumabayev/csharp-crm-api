using Microsoft.EntityFrameworkCore;
using Project.domain;
using Project.Infrastructure.Persistence;

namespace Project.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(User newUser)
    {
         await _dbContext.Users.AddAsync(newUser);
         await _dbContext.SaveChangesAsync();
    }
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username ==username);
    }
}