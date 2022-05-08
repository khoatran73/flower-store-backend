using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace store.Services;

public class CloudinaryService : ICloudinaryService
{
    private static Cloudinary cloudinary;

    private const string CloudName = "dqrkqvtjg";
    private const string ApiKey = "867148774581843";
    private const string ApiSecret = "2gmWUzRSn8YoFfJp0J2wray7GC4";
    
    public async Task<ImageUploadResult> UploadImage(string path, string folder)
    {
        var account = new Account(CloudName, ApiKey, ApiSecret);
        cloudinary = new Cloudinary(account);
        
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(path),
            Folder = folder
        };

        var result = cloudinary.Upload(uploadParams); 

        return result;
    }
}