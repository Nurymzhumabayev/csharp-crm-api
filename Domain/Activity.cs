using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Project.domain;

public enum ActivityKind
{
    Call,
    Meeting,
    Email
}

 
public  class Activity
{
    public Guid Id {get;set;}

    public required ActivityKind Kind {get;set;}
    public required string Description {get;set;}
    public DateTime DueTime {get;set;}
    public bool IsCompleted {get;set;} = false;
    public Contact? Contact {get;set;}
    public Guid ContactId {get;set;}

    private Activity(){}

    public static Activity Create(ActivityKind activityKind, string description, DateTime dueTime, Guid contactId)
    {
        if (string.IsNullOrWhiteSpace(description))
        throw new ArgumentException("Description cannot be empty");
        if (contactId == Guid.Empty)
        {
          throw new ArgumentException("ContactId cannot be emooty");
        }
        var activity = new Activity
        {
            Id = Guid.NewGuid(),
            Kind = activityKind,
            Description = description,
            DueTime = dueTime,
            ContactId = contactId
        };

        return activity;
    }
    public void Complete()
    {
        if (IsCompleted)
        {
            throw new InvalidOperationException("Activity is already completed.");
        }

        IsCompleted = true;
    }
    public void UpdateActivity(string? description, ActivityKind? activityKind,
                                DateTime? dateTime, Guid? contactId)
    {
        if(!string.IsNullOrWhiteSpace(description))
        Description = description;
        if (activityKind is not null)
        {
            Kind = activityKind.Value;
        }
        if (dateTime is not null)
        DueTime = dateTime.Value;
        if (contactId is not null)
        ContactId = contactId.Value;
    }
}

