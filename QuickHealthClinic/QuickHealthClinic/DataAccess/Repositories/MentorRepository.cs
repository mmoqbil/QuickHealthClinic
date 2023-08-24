using QuickHealthClinic.DataAccess.DbContexts;
using QuickHealthClinic.DataAccess.Entities;
using QuickHealthClinic.DataAccess.Repositories.Interfaces;

namespace QuickHealthClinic.DataAccess.Repositories
{
    public class MentorRepository : Repository<Mentor>, IMentorRepository
    {
        public MentorRepository(QuickHealthClinicContext context) : base(context)
        {
            DbSet = context.Mentors;
        }
    }
}
