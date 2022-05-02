using store.Dto.File;

namespace store.Services;

public interface IFileService
{
    Task<string> UploadFile(IFormFile fileUpload, string folder);
}