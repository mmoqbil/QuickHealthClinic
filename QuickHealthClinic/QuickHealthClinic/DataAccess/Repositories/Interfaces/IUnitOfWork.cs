namespace QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMentorRepository MentorRepository { get; }
        IStudentRepository StudentRepository { get; }
        IClinicRepository ClinicRepository { get; }
        Task SaveAsync();
    }
}
