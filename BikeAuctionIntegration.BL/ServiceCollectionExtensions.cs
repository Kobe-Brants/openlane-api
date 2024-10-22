using BikeAuctionIntegration.BL.Services.Bike;
using Microsoft.Extensions.DependencyInjection;

namespace BikeAuctionIntegration.BL
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBikeService, BikeService>();
        }
    }
}