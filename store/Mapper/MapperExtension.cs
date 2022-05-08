using AutoMapper;

namespace store.Mapper;

public static class MapperExtension
{
    public static IMapper AddMapper()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile(new ProductProfile());
            config.AddProfile(new AuthenticateProfile());
            config.AddProfile(new UserProfile());
            config.AddProfile(new StoreProfile());
            config.AddProfile(new CartProfile());
            config.AddProfile(new OrderProfile());
        });

        return mapperConfig.CreateMapper();
    }
}