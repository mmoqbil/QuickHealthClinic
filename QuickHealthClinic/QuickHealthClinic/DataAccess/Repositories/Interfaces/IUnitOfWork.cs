namespace QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMentorRepository MentorRepository { get; }
        IStudentRepository StudentRepository { get; }
        IClinicRepository ClinicRepository { get; }
        IVisitRepository VisitRepository { get; }
        IReferralRepository ReferralRepository { get; }
        Task SaveAsync();
    }
}
