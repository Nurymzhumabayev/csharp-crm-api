using MediatR;
using Project.domain;

namespace Project.Application.Deals;

public class GetDealByIdQuery : IRequest<Deal?>
{
    public required Guid Id {get;set;}
}