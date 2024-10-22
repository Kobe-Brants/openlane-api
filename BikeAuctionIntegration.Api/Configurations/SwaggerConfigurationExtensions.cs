namespace BikeAuctionIntegration.Api.Configurations;

public static class SwaggerConfigurationExtensions
{
     public static void ConfigureSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
    }
    
    public static void UseSwaggerConfig(this WebApplication app)
    {
        // var authenticationSettings = app.Services.GetRequiredService<IOptions<AuthenticationSettings>>().Value;

        app.UseSwagger();
        app.UseSwaggerUI();
    }
}