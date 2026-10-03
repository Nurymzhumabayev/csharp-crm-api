using System;

namespace Project.domain;

public class Contact
{
    public Guid Id {get; set;}
    public required string Name {get;set;}
    public required string Email{get;set;}

    private Contact() {}

    public static Contact Create(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
             throw new ArgumentException("Name cannot be empty", nameof(name));

        var contact = new Contact{
            Id = Guid.NewGuid(),
            Name = name,
            Email =email
        };
        
        return contact;
    }
    public void UpdateContact(string? name, string? email)
    {
        if (!string.IsNullOrWhiteSpace(name))
            Name = name;

        if (!string.IsNullOrWhiteSpace(email))
            Email = email;
    }
}