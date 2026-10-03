using System.Text.RegularExpressions;
using MediatR;
using Project.Application.Contacts;
using Project.Application.Users;

namespace Project.Api.Endpoints;

public class UserEndpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/users");
        
        group.MapPost("/register", async (RegisterUserCommand command, IMediator mediatr) =>
        {
            var user = await mediatr.Send(command);
            return Results.Created($"/users/{user.Id}", new { user.Id, user.Username });
        });
        group.MapPost("/login", async (LoginCommand command, IMediator mediator) =>
{
    var token = await mediator.Send(command);
    return token is null ? Results.Unauthorized() : Results.Ok(new { Token = token });
});
    }
}