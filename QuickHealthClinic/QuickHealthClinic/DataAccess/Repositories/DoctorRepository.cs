using QuickHealthClinic.DataAccess.DbContexts;
using QuickHealthClinic.DataAccess.Entities;
using QuickHealthClinic.DataAccess.Repositories.Interfaces;

namespace QuickHealthClinic.DataAccess.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(QuickHealthClinicContext context) : base(context)
        {
            DbSet = context.Doctors;
        }
    }
}
