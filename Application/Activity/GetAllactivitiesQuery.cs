using MediatR;
using Project.domain;

namespace Project.Application.Activities;

public class GetAllActivitiesQuery : IRequest<List<Activity>>
{

}