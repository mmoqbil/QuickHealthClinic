﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLifeCoachingClinic.DataAccess.Entities.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasColumnType("varchar(9)");
        }
    }
}
