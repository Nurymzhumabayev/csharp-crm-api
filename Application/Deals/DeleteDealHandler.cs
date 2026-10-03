using MediatR;
using Project.domain;

namespace Project.Application.Deals;

public class DeleteDealHandler : IRequestHandler<DeleteDealCommand, Deal?>
{
    private readonly IDealRepository _dealRepository;

    public DeleteDealHandler(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository;
    }
    public async Task<Deal?> Handle(DeleteDealCommand command, CancellationToken cancellationToken)
    {
        var index = await _dealRepository.GetByIdAsync(command.Id);

        if(index is null)
        {
            return null;
        }
        await _dealRepository.DeleteContact(index);
        return index;

    }
}