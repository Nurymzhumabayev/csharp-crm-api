using MediatR;
using Project.domain;

namespace Project.Application.Contacts;

public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, Contact?>
{
    private readonly IContactRepository _contactRepository;

    public DeleteContactHandler (IContactRepository contactRepository)
    {
        _contactRepository=contactRepository;
    }

    public async Task<Contact?> Handle(DeleteContactCommand command, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetByIdAsync(command.Id);
        if (contact is null)
        {
            return null;
        }
        await _contactRepository.DeleteContact(contact);
        return contact;
    }

}