using MediatR;
using Project.domain;

namespace Project.Application.Activities;

public class CreateActivityCommand : IRequest<Activity>
{
    public required ActivityKind Kind {get;set;}
    public required string Description {get;set;}
    public required DateTime Duetime{get;set;}
    public Guid ContactId {get;set;}
    
}