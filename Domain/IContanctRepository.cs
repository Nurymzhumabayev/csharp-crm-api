using Project.Application.Contacts;

namespace Project.domain;

public interface IContactRepository
{
    Task AddAsync(Contact contact);
    Task<Contact?> GetByIdAsync(Guid Id);
    Task<List<Contact>> GetAllContactsAsync();
    Task SaveChangesAsync(); 

    Task DeleteContact(Contact contact);

}