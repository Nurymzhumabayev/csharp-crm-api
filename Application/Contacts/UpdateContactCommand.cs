using System.Diagnostics.CodeAnalysis;
using MediatR;
using Project.domain;

namespace Project.Application.Contacts;

public record UpdateContactCommand : IRequest<Contact>
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}