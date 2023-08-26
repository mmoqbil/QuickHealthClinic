using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;

namespace QuickLifeCoachingClinic.DataAccess.Repositories
{
    public class ClinicRepository : Repository<Clinic>, IClinicRepository
    {
        public ClinicRepository(QuickLifeCoachingClinicContext context) : base(context)
        {
            DbSet = context.Clinics;
        }
    }
}
