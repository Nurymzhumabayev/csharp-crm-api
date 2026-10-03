using MediatR;
using Project.domain;
namespace Project.Application.Activities;

public class GetActivityByIdQuery : IRequest<Activity?>
{
    public Guid Id{get;set;}
}