using QuickHealthClinic.DataAccess.Repositories.Interfaces;

namespace QuickHealthClinic.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorRepository DoctorRepository => throw new NotImplementedException();

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
