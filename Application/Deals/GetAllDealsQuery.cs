using MediatR;
using  Project.domain;
namespace Project.Application.Deals;

public class GetAllDealsQuery : IRequest<List<Deal>>
{
    
}