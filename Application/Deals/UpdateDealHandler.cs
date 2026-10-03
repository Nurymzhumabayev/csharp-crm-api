using MediatR;
using Project.domain;

namespace Project.Application.Deals;

public class UpdateDealHandler : IRequestHandler<UpdateDealCommand, Deal?>
{
    private readonly IDealRepository _repository;
    public UpdateDealHandler(IDealRepository repository)
    {
        _repository = repository;
    }
    public async Task<Deal?> Handle(UpdateDealCommand command, CancellationToken cancellationToken)
    {
        var index = await _repository.GetByIdAsync(command.Id);
        if(index is null)
        {
            return null;
        }
        index.UpdateDeal(command.Title,command.Amount);
        await _repository.SaveChangesAsync();
        return index;
    }
}