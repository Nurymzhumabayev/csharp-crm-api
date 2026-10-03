using MediatR;
using Microsoft.AspNetCore.Identity;
using Project.domain;
using Project.Infrastructure;

namespace Project.Application.Users;

public class LoginHandler : IRequestHandler<LoginCommand, string?>
{
    private readonly IUserRepository _repository;
    private readonly TokenProvider _tokenProvider;
    private readonly PasswordHasher<User> _passwordHasher = new();
    public LoginHandler(IUserRepository repository, TokenProvider tokenProvider)
    {
        _repository = repository;
        _tokenProvider = tokenProvider;
    }
    public async Task<string?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByUsernameAsync(request.Username);
        if(user is null)
        return null;

        var result = _passwordHasher.VerifyHashedPassword(user,user.PasswordHash ,request.Password);
        if (result == PasswordVerificationResult.Failed)
        return null;

        return _tokenProvider.Create(user);
    }

}