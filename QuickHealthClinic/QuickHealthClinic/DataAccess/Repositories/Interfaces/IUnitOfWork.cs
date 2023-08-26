namespace QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMentorRepository MentorRepository { get; }
        IClinicRepository ClinicRepository { get; }
        Task SaveAsync();
    }
}
