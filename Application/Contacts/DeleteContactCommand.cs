using MediatR;
using Project.domain;

namespace Project.Application.Contacts;

public class DeleteContactCommand : IRequest<Contact?>
{
    public required Guid Id{get;set;}
}