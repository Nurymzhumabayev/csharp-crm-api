namespace Project.domain;

public interface IDealRepository
{
    Task AddAsync(Deal deal);
    Task<Deal?> GetByIdAsync(Guid Id);
    Task<List<Deal>> GetAllDealsAsync();
    Task SaveChangesAsync(); 

    Task DeleteContact(Deal deal);
}