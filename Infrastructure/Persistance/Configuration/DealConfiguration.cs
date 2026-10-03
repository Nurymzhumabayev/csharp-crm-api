using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.domain;

namespace Project.Infrastructure.Persistence.Configuration;

public class DealConfiguration : IEntityTypeConfiguration<Deal>
{
    public void Configure(EntityTypeBuilder<Deal> builder)
    {
        builder.HasKey(c=>c.Id);
        builder.Property(c=>c.Title).HasMaxLength(100).IsRequired();
        builder.Property(c=>c.Amount).HasPrecision(18,2);
        builder.HasOne(c => c.Contact)
        .WithMany()
        .HasForeignKey(d => d.ContactId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}