using Microsoft.EntityFrameworkCore;
using Project.domain;
using Project.Infrastructure.Persistence;

namespace Project.Infrastructure.Repositories;


public class ActivityRepository : IActivityRepository
{
    private readonly AppDbContext _dbcontext;
    public ActivityRepository(AppDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public async Task AddSync(Activity activity)
    {
        await _dbcontext.Activities.AddAsync(activity);
        await _dbcontext.SaveChangesAsync();
    }
    public async Task SaveAsync()
    {
        await _dbcontext.SaveChangesAsync();
    }
    public async Task<List<Activity>> GetActivityAsync()
    {
        return await _dbcontext.Activities
        .AsNoTracking()
        .ToListAsync();
    }
    public async Task<Activity?> GetByIdAsync(Guid Id)
    {
        var index = await _dbcontext.Activities.FindAsync(Id);
        return index;
    }
}