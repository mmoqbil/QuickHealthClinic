using QuickHealthClinic.DataAccess.DbContexts;
using QuickHealthClinic.DataAccess.Repositories.Interfaces;

namespace QuickHealthClinic.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuickHealthClinicContext _context;
        public UnitOfWork(QuickHealthClinicContext context)
        {
            _context = context;
            DoctorRepository = new DoctorRepository(_context);
        }
        public IDoctorRepository DoctorRepository { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
