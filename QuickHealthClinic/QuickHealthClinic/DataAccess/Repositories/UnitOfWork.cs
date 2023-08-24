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
            MentorRepository = new MentorRepository(_context);
        }
        public IMentorRepository MentorRepository { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _context?.Dispose();
        }
    }
}
