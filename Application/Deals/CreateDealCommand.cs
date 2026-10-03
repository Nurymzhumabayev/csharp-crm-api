using MediatR;
using Project.domain;

namespace Project.Application.Deals;

public class CreateDealCommand : IRequest<Deal>
{
    public required string Title {get;set;}
    public required decimal Amount {get;set;}
    public required Guid ContactId {get;set;}
    
}