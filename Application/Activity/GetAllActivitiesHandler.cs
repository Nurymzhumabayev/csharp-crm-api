using MediatR;
using Project.domain;

namespace Project.Application.Activities;

public class GetAllActivitiesHandler : IRequestHandler<GetAllActivitiesQuery, List<Activity>>
{
    private readonly IActivityRepository _repository;
    public GetAllActivitiesHandler(IActivityRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Activity>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetActivityAsync();
    }
}