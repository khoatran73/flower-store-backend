namespace store.Dto.File;

public class FileCreateDto
{
    public string Id { get; set; } = null!;
    public string? FileName { get; set; }
    public string? FileLocation { get; set; }
    public string? RootFolder { get; set; }
}