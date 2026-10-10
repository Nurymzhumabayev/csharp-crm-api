using MediatR;
using Project.domain;

namespace Project.Application.Activities;

public class UpdateActivityHandler : IRequestHandler<UpdateActivityCommand, Activity?>
{
    private readonly IActivityRepository _repository;
    public UpdateActivityHandler(IActivityRepository repository)
    {
        _repository = repository;
    }
    public async Task<Activity?> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var index = await _repository.GetByIdAsync(request.Id);
        if (index is null)
        {
            return null;
        }
        index.UpdateActivity(request.Description,request.Kind,request.DueTime,request.ContactId);
        await _repository.SaveAsync();

        return index;

    }
}