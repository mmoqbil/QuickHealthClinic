using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLifeCoachingClinic.DataAccess.Entities.Configurations
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.HasOne(v => v.Student)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.StudentId);

            builder.HasOne(v => v.Mentor)
            .WithMany(d => d.Visits)
            .HasForeignKey(v => v.MentorId)
            .OnDelete(DeleteBehavior.ClientCascade);

            builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}
