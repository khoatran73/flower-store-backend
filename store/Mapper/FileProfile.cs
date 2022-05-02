using AutoMapper;
using store.demoentities;
using store.Dto.File;

namespace store.Mapper;

public class FileProfile : Profile
{
    public FileProfile()
    {
        CreateMap<FileEntry, FileDto>();
        CreateMap<FileCreateDto, FileEntry>();
    }
    
}