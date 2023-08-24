using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;

namespace QuickLifeCoachingClinic.DataAccess.Repositories
{
    public class MentorRepository : Repository<Mentor>, IMentorRepository
    {
        public MentorRepository(QuickHealthClinicContext context) : base(context)
        {
            DbSet = context.Mentors;
        }
    }
}
