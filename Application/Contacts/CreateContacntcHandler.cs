using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Project.domain;
using Project.Infrastructure.Repositories;

namespace Project.Application.Contacts;

public class CreateContactHandler : IRequestHandler<CreateContactCommand, Contact>
{
    private readonly IContactRepository _contactRepository;

    public CreateContactHandler(IContactRepository contactRepository)
    {
        _contactRepository=contactRepository;
    }
    public async Task<Contact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = Contact.Create(request.Name, request.Email);
        await _contactRepository.AddAsync(contact);
        return contact;
    }
}