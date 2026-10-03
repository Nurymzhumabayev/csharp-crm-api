namespace Project.domain;

public interface IActivityRepository
{
    Task AddSync(Activity activity);
    Task SaveAsync();
    Task<List<Activity>> GetActivityAsync();
    Task<Activity?> GetByIdAsync(Guid Id);
}