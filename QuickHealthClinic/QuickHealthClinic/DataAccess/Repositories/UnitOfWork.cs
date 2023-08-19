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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _context?.Dispose();
        }
    }
}
