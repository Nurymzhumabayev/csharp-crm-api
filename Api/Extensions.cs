using Project.Api.Endpoints;

namespace Project.Api;

public static class Extensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = new List<IEndpoint>
        {
            new ContactEndpoints(),
            new DealEndpoints(),
            new UserEndpoint() 
        };
        foreach (var el in endpoints)
        {
            el.MapEndpoints(app);
        }
    }
}