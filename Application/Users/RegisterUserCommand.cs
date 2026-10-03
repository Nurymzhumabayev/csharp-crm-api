using MediatR;
using Project.domain;

namespace Project.Application.Users;

public class RegisterUserCommand : IRequest<User>
{
    public required string Username{get;set;}
    public required string PasswordHash{get;set;}
    public required string Role{get;set;}
}