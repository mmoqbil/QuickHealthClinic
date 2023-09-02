using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLifeCoachingClinic.DataAccess.Entities.Configurations
{
    public class MentorConfiguration : IEntityTypeConfiguration<Mentor>
    {
        public void Configure(EntityTypeBuilder<Mentor> builder)
        {
            builder.HasMany(d => d.Students)
               .WithMany(p => p.Mentors)
               .UsingEntity<MentorStudent>(
                   dp => dp.HasOne(p => p.Student)
                       .WithMany()
                       .HasForeignKey(dp => dp.StudentId),
                   dp => dp.HasOne(d => d.Mentor)
                       .WithMany()
                       .HasForeignKey(dp => dp.MentorId)
                       .OnDelete(DeleteBehavior.ClientCascade),
                   dp => { dp.HasKey(x => new { x.StudentId, x.MentorId }); }
               );

            builder.Property(d => d.FirstName)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(d => d.LastName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(d => d.PhoneNumber)
            .IsRequired()
            .HasColumnType("varchar(9)");

            builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(d => d.Created)
            .HasDefaultValueSql("getdate()");
        }
    }
}
