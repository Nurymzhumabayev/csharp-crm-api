using MediatR;
using Project.domain;

namespace Project.Application.Deals;

public class CloseDealHandler : IRequestHandler<CloseDealCommand, Deal?>
{
    private readonly IDealRepository _repository;

    public CloseDealHandler(IDealRepository repository)
    {
        _repository = repository;
    }
    public async Task<Deal?> Handle(CloseDealCommand command, CancellationToken cancellationToken)
    {
        var index = await _repository.GetByIdAsync(command.Id);

        if (index is null)
        {
            return null;
        }
        index.Close(command.won);
        await _repository.SaveChangesAsync();

        return index;
    }
}