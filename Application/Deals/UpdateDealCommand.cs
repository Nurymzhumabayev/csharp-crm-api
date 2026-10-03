using MediatR;
using Project.domain;

namespace Project.Application.Deals;

public class UpdateDealCommand : IRequest<Deal?>
{
    public required Guid Id {get;set;}
    public string? Title {get;set;}
    public decimal? Amount{get;set;}
}