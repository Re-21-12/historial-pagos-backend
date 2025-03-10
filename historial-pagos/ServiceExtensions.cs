public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        // Agregar Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Agregar otros servicios que puedas necesitar
        // services.AddScoped<IMyService, MyService>();
    }
}