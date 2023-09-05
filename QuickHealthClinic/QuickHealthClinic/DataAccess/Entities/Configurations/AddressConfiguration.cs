using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLifeCoachingClinic.DataAccess.Entities.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(c => c.Clinic)
            .WithOne(a => a.Address)
            .HasForeignKey<Clinic>(c => c.AddressId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Mentor)
            .WithOne(a => a.Address)
            .HasForeignKey<Mentor>(p => p.AddressId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Student)
            .WithOne(a => a.Address)
            .HasForeignKey<Student>(p => p.AddressId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(a => a.PostalCode)
            .IsRequired()
            .HasColumnType("varchar(6)");
        }
    }
}
