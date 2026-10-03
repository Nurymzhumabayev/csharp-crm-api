using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.domain;
using Project.Infrastructure.Persistence;

namespace Project.Application.Contacts;

public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, List<Contact>>
{
    private readonly IContactRepository _repository;
    public GetAllContactsHandler(IContactRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Contact>> Handle(GetAllContactsQuery contactsQuery, CancellationToken cancellationToken)
    {
        return await _repository.GetAllContactsAsync();
    }
}