using AutoMapper;

namespace store.Mapper;

public static class MapperExtension
{
    public static IMapper AddMapper()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile(new ProductProfile());
            config.AddProfile(new FileProfile());
        });

        return mapperConfig.CreateMapper();
    }
}