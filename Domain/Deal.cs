using System.Runtime.InteropServices;

namespace Project.domain;

public enum DealStatus
{
    Open,
    Won,
    Lost
}
public class Deal
{
    public Guid Id {get;set;}
    public required string Title {get;set;}
    public required decimal Amount {get;set;}
    public DealStatus Status {get;set;} = DealStatus.Open;
    public Contact? Contact {get;set;}
    public Guid ContactId {get;set;}

    private Deal(){}

    public static Deal Create (string title, decimal amount,Guid contactId)
    {
        if (string.IsNullOrWhiteSpace(title))
        throw new ArgumentException("Title cannot be empty");

        if (amount <= 0)
          throw new ArgumentOutOfRangeException(nameof(amount),"Amount cannot be less or equal 0");
        if (contactId == Guid.Empty)
            throw new ArgumentException("ContactId cannot be empty");
        

        var deal = new Deal
        {
            Id = Guid.NewGuid(),
            Title = title,
            Amount = amount,
            ContactId = contactId
            
        };

        return deal;
    }

    public void Close(bool won)
    {
        if (Status != DealStatus.Open)
            throw new InvalidOperationException("Deal is already closed");

        if (won)
        Status = DealStatus.Won;
        else
        Status = DealStatus.Lost;
    }
    public void UpdateDeal(string? title, decimal? amount)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            Title = title;
        }
        if (amount is not null)
        {
            Amount = amount.Value;
        }
    }
}