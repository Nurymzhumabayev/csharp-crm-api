using MediatR;
using Project.domain;

namespace Project.Application.Contacts;

public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, Contact?>
{
    private readonly IContactRepository _repository;

    public GetContactByIdHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact?> Handle(GetContactByIdQuery query, CancellationToken cancellationToken)
    {
        var getContact = await _repository.GetByIdAsync(query.Id);
        return getContact;
    }
}