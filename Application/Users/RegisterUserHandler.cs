using MediatR;
using Microsoft.AspNetCore.Identity;
using Project.domain;

namespace Project.Application.Users;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, User>
{
    private readonly IUserRepository _repository;
    private readonly PasswordHasher<User> _passwordHasher = new();
    public RegisterUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordHasher.HashPassword(null!,request.PasswordHash);
        var user = User.Create(request.Username, passwordHash,request.Role);

        await _repository.AddAsync(user);
        return user;
    }
}