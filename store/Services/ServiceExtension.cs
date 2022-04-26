namespace store.Services;

public static class ServiceExtension
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
    }
}