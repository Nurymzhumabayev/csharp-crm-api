using MediatR;
using Project.domain;

namespace Project.Application.Deals;

public class CloseDealCommand : IRequest<Deal?>
{
    public required Guid Id {get;set;}
    public required bool won {get;set;}
}