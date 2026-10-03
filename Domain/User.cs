using System.Diagnostics.CodeAnalysis;

namespace Project.domain;

public class User
{
    public Guid Id {get;set;}
    public required string Username {get;set;}
    public required string PasswordHash {get;set;}
    public required string Role{get;set;}
    private User(){}

    public static User Create(string username, string passwordHash, string role)
    {
        if (string.IsNullOrWhiteSpace(username))
             throw new ArgumentException("Username cannot be empty", nameof(username));
        if (string.IsNullOrWhiteSpace(passwordHash))
             throw new ArgumentException("Password cannot be empty", nameof(passwordHash));
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            PasswordHash = passwordHash,
            Role = role
        };
        return user;
    }
}