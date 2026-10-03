using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.domain;

namespace Project.Infrastructure.Persistence.Configuration;


public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(x => x.Id);
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c=>c.Email).HasMaxLength(100).IsRequired();
        builder.HasIndex(c=>c.Email).IsUnique();

    }
}