namespace BikeAuctionIntegration.Api.Configurations;

public static class ApplicationConfigurationExtensions
{
    public static void ConfigureCors(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddCors();
    }
}