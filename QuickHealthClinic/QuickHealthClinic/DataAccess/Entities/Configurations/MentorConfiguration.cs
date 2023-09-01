﻿using Microsoft.EntityFrameworkCore;
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
        }
    }
}