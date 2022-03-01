using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinklogicAssessment.Domain.Events;

namespace ThinklogicAssessment.Infra.Mappings
{
    public class EventsMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");

            // Keys
            builder.HasKey(x => x.Id).IsClustered(false);

            // Props
            builder.Property(x => x.StartDate).IsRequired().HasComment("Start date of the event.");
            builder.Property(x => x.EndDate).IsRequired().HasComment("End date of the event.");
            builder.Property(x => x.Title).HasMaxLength(255).IsRequired().HasComment("Title of the event.");
            builder.Property(x => x.Location).HasMaxLength(500).HasComment("Location of the event.");
            builder.Property(x => x.Description).HasMaxLength(5000).HasComment("Description of the event.");

            // Indexes
            builder.HasIndex(x => x.StartDate).IsClustered();
        }
    }
}
