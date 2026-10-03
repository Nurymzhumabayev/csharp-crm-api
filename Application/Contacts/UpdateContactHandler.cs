using MediatR;
using Project.domain;

namespace Project.Application.Contacts;

public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, Contact?>
{
    private readonly IContactRepository _repository;

    public UpdateContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact?> Handle(UpdateContactCommand updateContact, CancellationToken cancellationToken)
    {
         var index = await _repository.GetByIdAsync(updateContact.Id);
         if (index is null) return null;

         index.UpdateContact(updateContact.Name, updateContact.Email);
         await _repository.SaveChangesAsync();

         return index;

    }
}