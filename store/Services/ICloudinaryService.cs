using CloudinaryDotNet.Actions;

namespace store.Services;

public interface ICloudinaryService
{
    Task<ImageUploadResult> UploadImage(string path, string folder);
}