using QuickLifeCoachingClinic.DTOs.ImageDto;

namespace QuickLifeCoachingClinic.Services.FileServices
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public Task<string> SaveFile(CreateImageDto file)
        {
            throw new NotImplementedException();
        }
    }
}
