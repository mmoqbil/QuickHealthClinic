using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;

namespace QuickLifeCoachingClinic.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuickLifeCoachingClinicContext _context;
        public UnitOfWork(QuickLifeCoachingClinicContext context)
        {
            _context = context;
            ClinicRepository = new ClinicRepository(_context);
            MentorRepository = new MentorRepository(_context);
            StudentRepository = new StudentRepository(_context);
            VisitRepository = new VisitRepository(_context);
        }
        public IMentorRepository MentorRepository { get; }
        public IClinicRepository ClinicRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public IVisitRepository VisitRepository { get; }

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
