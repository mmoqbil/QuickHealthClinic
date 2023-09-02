using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLifeCoachingClinic.DataAccess.Entities.Configurations
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasMany(c => c.Students)
            .WithMany(p => p.Clinics)
            .UsingEntity<ClinicStudent>(
                cp => cp.HasOne(p => p.Student)
                    .WithMany()
                    .HasForeignKey(cp => cp.StudentId),
                cp => cp.HasOne(c => c.Clinic)
                    .WithMany()
                    .HasForeignKey(cp => cp.ClinicId)
                    .OnDelete(DeleteBehavior.ClientCascade),
                cp => { cp.HasKey(x => new { x.StudentId, x.ClinicId }); }
            );

            builder.HasMany(c => c.Mentors)
           .WithMany(d => d.Clinics)
           .UsingEntity<ClinicMentor>(
               cd => cd.HasOne(d => d.Mentor)
                   .WithMany()
                   .HasForeignKey(cd => cd.MentorId),
               cd => cd.HasOne(c => c.Clinic)
                   .WithMany()
                   .HasForeignKey(cd => cd.ClinicId)
                   .OnDelete(DeleteBehavior.ClientCascade),
               cd => { cd.HasKey(x => new { x.MentorId, x.ClinicId }); }
           );

            builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}
