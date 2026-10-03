using MediatR;
using Project.Application.Deals;

namespace Project.Api.Endpoints;

public class DealEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/deal");

        group.MapPost("/", async (CreateDealCommand deal, IMediator mediator) =>
        {
            var newDeal = await mediator.Send(deal);
            return Results.Created($"/contacts/{newDeal.Id}", deal);
        });

        group.MapGet("/", async (IMediator mediator) =>
        {
            var list = await mediator.Send(new GetAllDealsQuery());
            return Results.Ok(list);
        });
        group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            var deals = new GetDealByIdQuery{Id = id};
            var send = await mediator.Send(deals);
            return send is null ? Results.NotFound() : Results.Ok(send);
        });
        group.MapPut("/{id:guid}/close", async (Guid id, bool Won, IMediator mediator) =>
        {
            var command = new CloseDealCommand{Id = id, won = Won};
            var deal = await mediator.Send(command);
            return deal is null ? Results.NotFound(): Results.Ok(deal);
        });
        group.MapPut("/{id:guid}", async (Guid id, UpdateDealCommand command, IMediator mediator) =>
        {
            command.Id = id;
            var deal = await mediator.Send(command);
            return deal is null ? Results.NotFound() : Results.Ok(deal);
        });
        group.MapDelete("/{id:guid}", async (Guid id, IMediator mediatr) =>
        {
            var command = new DeleteDealCommand{Id = id};
            var deal = await mediatr.Send(command);

            return deal is null ? Results.NotFound() : Results.Ok(deal);
        });
    }
}