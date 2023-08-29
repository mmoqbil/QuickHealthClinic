using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;

namespace QuickLifeCoachingClinic.DataAccess.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(QuickLifeCoachingClinicContext context) : base(context)
        {
            DbSet = context.Students;
        }
    }
}
