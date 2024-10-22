using System.Text.Json;
using BikeAuctionIntegration.Core;
using Microsoft.Extensions.Configuration;

namespace BikeAuctionIntegration.BL.Services.Bike;

public class BikeService(IConfiguration configuration) : IBikeService
{
    public async Task<HandlerResult<List<Domain.Bike>>> GetBikesAsync(string? bikeContainerId, CancellationToken cancellationToken)
    {
        const string filePath = configuration.GetValue<string>("BikeData:FilePath");
        
        if (!File.Exists(filePath))
            return HandlerResult<List<Domain.Bike>>.Fail("Something went wrong");
        
        var jsonData = await File.ReadAllTextAsync(filePath, cancellationToken);
        var bikes = JsonSerializer.Deserialize<List<Domain.Bike>>(jsonData) ?? [];

        if (bikeContainerId != null) return HandlerResult.Success(bikes);

        var bikesOfContainer = bikes.FindAll(c => c.BikeContainerId == bikeContainerId);
        return HandlerResult<List<Domain.Bike>>.Success(bikesOfContainer);
    }
}