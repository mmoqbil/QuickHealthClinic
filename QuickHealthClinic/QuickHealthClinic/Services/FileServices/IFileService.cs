using QuickLifeCoachingClinic.DTOs.ImageDto;

namespace QuickLifeCoachingClinic.Services.FileServices
{
    public interface IFileService
    {
        Task<string> SaveFile(CreateImageDto file);
    }
}
