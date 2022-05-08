using AutoMapper;
using store.Entities;

namespace store.Services;

public class FileService : IFileService
{
    private readonly henrystoreContext _context;
    private readonly IMapper _mapper;
    private readonly IHostEnvironment _hostingEnvironment;
    public static readonly string[] AllowExt = {".png", ".jpg", ".jpeg", ".webp"};

    public FileService(henrystoreContext context, IMapper mapper, IHostEnvironment hostingEnvironment)
    {
        _context = context;
        _mapper = mapper;
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task<string> UploadFile(IFormFile file, string folder)
    {
        var exists = Directory.Exists(folder);
        if (!exists) Directory.CreateDirectory(folder);

        var fileExtension = Path.GetExtension(file.FileName);
        if (!AllowExt.Contains(fileExtension)) throw new Exception("Định dạng file không hợp lệ");

        var filePath = Path.Combine(folder,
            $"{Guid.NewGuid().ToString()}{fileExtension}");

        //create file entry record
        await using var stream = File.Create(filePath);
        await file.CopyToAsync(stream);

        return Path.GetFullPath(filePath);
    }
}