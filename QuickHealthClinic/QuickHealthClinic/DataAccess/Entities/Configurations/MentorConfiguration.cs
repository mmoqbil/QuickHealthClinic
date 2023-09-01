using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickLifeCoachingClinic.DataAccess.Entities.Configurations
{
    public class MentorConfiguration : IEntityTypeConfiguration<Mentor>
    {
        public void Configure(EntityTypeBuilder<Mentor> builder)
        {
        }
    }
}
