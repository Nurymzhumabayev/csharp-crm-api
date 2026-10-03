using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.domain;
using Project.Infrastructure.Persistence;

namespace Project.Application.Deals;

public class GetAllDealsHandler : IRequestHandler<GetAllDealsQuery, List<Deal>>
{
    private readonly IDealRepository _repository;
    public GetAllDealsHandler(IDealRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Deal>> Handle(GetAllDealsQuery query, CancellationToken cancellationToken)
    {
        return await _repository.GetAllDealsAsync();
    }
}