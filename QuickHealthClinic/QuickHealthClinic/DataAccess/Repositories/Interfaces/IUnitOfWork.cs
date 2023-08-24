namespace QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMentorRepository MentorRepository { get; }
        Task SaveAsync();
    }
}
