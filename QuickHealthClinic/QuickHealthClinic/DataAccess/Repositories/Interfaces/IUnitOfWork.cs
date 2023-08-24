namespace QuickHealthClinic.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMentorRepository DoctorRepository { get; }
        Task SaveAsync();
    }
}
