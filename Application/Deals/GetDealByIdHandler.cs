using MediatR;
using Project.Application.Contacts;
using Project.domain;
using Project.Infrastructure.Repositories;

namespace Project.Application.Deals;

public class GetDealByIdAsyncHandler : IRequestHandler<GetDealByIdQuery, Deal?>
{
    private readonly IDealRepository _repository;
    public GetDealByIdAsyncHandler(IDealRepository repository)
    {
        _repository = repository;
    }
    public async Task<Deal?> Handle(GetDealByIdQuery query, CancellationToken cancellationToken)
    {
        var deal = await _repository.GetByIdAsync(query.Id);
        return deal;
    }
}