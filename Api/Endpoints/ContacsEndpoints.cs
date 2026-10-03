using MediatR;
using Project.Application.Contacts;

namespace Project.Api.Endpoints;

public class ContactEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/contacts");

        group.MapPost("/", async (CreateContactCommand contact, IMediator mediator) =>
        {
            var newContact = await mediator.Send(contact);
            return Results.Created($"/contacts/{newContact.Id}", contact);
        }).RequireAuthorization(policy => policy.RequireRole("Admin"));

        group.MapGet("/", async (IMediator mediator) =>
        {
            var list = await mediator.Send(new GetAllContactsQuery());
            return Results.Ok(list);
        });

        group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var query = new GetContactByIdQuery{ Id = id};
            var contact = await mediator.Send(query);
            return contact is null ? Results.NotFound() : Results.Ok(contact);
        });
        group.MapPut("/{id:guid}", async (Guid Id, UpdateContactCommand command,
        IMediator meadiator) =>
        {
            command.Id = Id;
            var contact = await meadiator.Send(command);
            return contact is null ? Results.NotFound() : Results.Ok(contact);
        } )
        .RequireAuthorization(policy => policy.RequireRole("Admin"));
        group.MapDelete("/{id:guid}", async (Guid id, IMediator mediatr) =>
        {
             var command = new DeleteContactCommand{Id=id};
             var contact = await mediatr.Send(command);

             return contact is null ? Results.NotFound() : Results.Ok(contact);
        }).RequireAuthorization(policy => policy.RequireRole("Admin"));

    }
}