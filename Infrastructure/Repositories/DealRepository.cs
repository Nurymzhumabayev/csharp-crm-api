using System.Data;
using Microsoft.EntityFrameworkCore;
using Project.domain;
using Project.Infrastructure.Persistence;

namespace Project.Infrastructure.Repositories;

public class DealRepository : IDealRepository
{
    private readonly AppDbContext _dbContext;

    public DealRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Deal deal){
        await _dbContext.Deals.AddAsync(deal);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<Deal?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Deals
        .Include(d => d.Contact)
        .FirstOrDefaultAsync(c => c.Id == id);
        
    }
    public async Task<List<Deal>> GetAllDealsAsync()
    {
        return await _dbContext.Deals

        .AsNoTracking()
        .Include(d => d.Contact)
        .ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteContact(Deal deal)
    {
        _dbContext.Deals.Remove(deal);
        await _dbContext.SaveChangesAsync();
    }
}