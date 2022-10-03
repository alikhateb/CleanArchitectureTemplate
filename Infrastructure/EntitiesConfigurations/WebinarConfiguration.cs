using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfigurations
{
    public class WebinarConfiguration : IEntityTypeConfiguration<Webinar>
    {
        public void Configure(EntityTypeBuilder<Webinar> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.HasData(new List<Webinar>()
            {
                new Webinar(Guid.NewGuid(), "ali",new DateTime(2000, 10, 30)),
                new Webinar(Guid.NewGuid(), "ahmed",new DateTime(2000, 5, 15)),
                new Webinar(Guid.NewGuid(), "sayed",new DateTime(2000, 6, 5)),
                new Webinar(Guid.NewGuid(), "kareem",new DateTime(2000, 1, 12)),
                new Webinar(Guid.NewGuid(), "pepo",new DateTime(2000, 2, 17)),
                new Webinar(Guid.NewGuid(), "mohamed",new DateTime(2000, 9, 23)),
            });
        }
    }
}
