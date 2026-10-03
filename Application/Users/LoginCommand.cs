using MediatR;

namespace Project.Application.Users;

public class LoginCommand : IRequest<string?>
{
    public required string Username {get;set;}
    public required string Password {get;set;}
    
}