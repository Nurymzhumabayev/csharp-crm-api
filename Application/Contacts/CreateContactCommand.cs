using MediatR;
using Project.domain;

namespace Project.Application.Contacts;

public class CreateContactCommand : IRequest<Contact>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}