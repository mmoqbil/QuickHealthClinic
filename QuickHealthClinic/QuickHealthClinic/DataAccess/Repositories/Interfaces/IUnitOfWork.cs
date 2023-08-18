namespace QuickHealthClinic.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDoctorRepository DoctorRepository { get; }
        Task SaveAsync();
    }
}
