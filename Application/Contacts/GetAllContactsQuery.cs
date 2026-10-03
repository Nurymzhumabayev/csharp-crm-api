using MediatR;
using Project.domain;

namespace Project.Application.Contacts;

public class GetAllContactsQuery : IRequest<List<Contact>> 
{
    
}