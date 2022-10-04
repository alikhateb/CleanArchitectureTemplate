using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfigurations;

public class WebinarConfiguration : IEntityTypeConfiguration<Webinar>
{
    public void Configure(EntityTypeBuilder<Webinar> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasData(new List<Webinar>
        {
            new(Guid.NewGuid(), "ali", new DateTime(2000, 10, 30)),
            new(Guid.NewGuid(), "ahmed", new DateTime(2000, 5, 15)),
            new(Guid.NewGuid(), "sayed", new DateTime(2000, 6, 5)),
            new(Guid.NewGuid(), "kareem", new DateTime(2000, 1, 12)),
            new(Guid.NewGuid(), "pepo", new DateTime(2000, 2, 17)),
            new(Guid.NewGuid(), "mohamed", new DateTime(2000, 9, 23))
        });
    }
}