using BikeAuctionIntegration.Core.Mapper;

namespace BikeAuctionIntegration.Api.Configurations;

public static class AutoMapperConfigurationExtensions
{
    public static void ConfigureAutoMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile));
    }
}