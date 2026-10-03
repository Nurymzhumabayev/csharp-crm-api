using Microsoft.EntityFrameworkCore;
using Project.Application.Contacts;
using Project.domain;
using Project.Infrastructure.Persistence;

namespace Project.Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _repository;

    public ContactRepository(AppDbContext repository)
    {
        _repository = repository;
    }
    public async Task AddAsync(Contact contact)
    {
        await _repository.Contacts.AddAsync(contact);
        await _repository.SaveChangesAsync();
    }
    public async Task<Contact?> GetByIdAsync(Guid Id)
    {
        var index = await _repository.Contacts.FindAsync(Id);
        return index;
    }
    public async Task<List<Contact>> GetAllContactsAsync()
    {
        return await _repository.Contacts
        .AsNoTracking()
        .ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteContact(Contact contact)
    {
        _repository.Contacts.Remove(contact);

        await _repository.SaveChangesAsync();
    }
}
