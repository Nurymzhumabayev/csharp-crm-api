using System.Diagnostics;
using MediatR;
using Project.domain;

namespace Project.Application.Activities;

public class CreateActivityHandler : IRequestHandler<CreateActivityCommand, Project.domain.Activity>
{
    private readonly IActivityRepository _repository;
    public CreateActivityHandler(IActivityRepository repository)
    {
        _repository = repository;
    }
    public async Task<Project.domain.Activity> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var newActivity = Project.domain.Activity.Create(request.Kind,request.Description,request.Duetime,request.ContactId);
        await _repository.AddSync(newActivity);
        return newActivity;
    }
}