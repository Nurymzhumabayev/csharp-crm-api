
using System.Reflection;
using MediatR;
using Project.domain;

namespace Project.Application.Deals;

public class CreateDealHandler : IRequestHandler<CreateDealCommand, Deal>
{

    private readonly IDealRepository _dealRepository;
    private readonly IContactRepository _contactRepository;

    public CreateDealHandler(IDealRepository dealRepository, IContactRepository contactRepository)
    {
        _dealRepository = dealRepository;
        _contactRepository = contactRepository;
    }
    public async Task<Deal> Handle(CreateDealCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetByIdAsync(request.ContactId);
        if (contact is null)
        {
             throw new ArgumentException($"Contact with id {request.ContactId} does not exist");       
        }
        var deal = Deal.Create(request.Title, request.Amount, request.ContactId);
        await _dealRepository.AddAsync(deal);
        return deal;

    }
}