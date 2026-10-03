using MediatR;
using Project.domain;

namespace Project.Application.Activities;

public class UpdateActivityCommand : IRequest<Activity?>
{
    public Guid Id{get;set;}
    public required ActivityKind Kind {get;set;}
    public required string Description {get;set;}
    public DateTime DueTime {get;set;}
    public bool IsCompleted {get;set;} = false;
    public Contact? Contact {get;set;}
    public Guid ContactId {get;set;}
}