using AutoMapper;

namespace store.Mapper;

public static class MapperExtension
{
    public static IMapper AddMapper()
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ProductProfile());
        });

        return mapperConfig.CreateMapper();
    }
}