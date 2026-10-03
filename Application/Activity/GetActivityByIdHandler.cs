using MediatR;
using Project.domain;
namespace Project.Application.Activities;

public class GetActivityByIdHandler : IRequestHandler<GetActivityByIdQuery, Activity?>
{
    private readonly IActivityRepository _repository;
    public GetActivityByIdHandler(IActivityRepository repository)
    {
        _repository = repository;
    }
    public async Task<Activity?> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await _repository.GetByIdAsync(request.Id);
        if (activity is null)
        return null;

        return activity;
    }
}