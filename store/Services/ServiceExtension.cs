namespace store.Services;

public static class ServiceExtension
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IFileService, FileService>();
        services.AddTransient<IAuthenticateService, AuthenticateService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IStoreService, StoreService>();
    }
}