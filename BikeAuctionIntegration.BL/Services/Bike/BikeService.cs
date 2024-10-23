using System.Text.Json;
using BikeAuctionIntegration.Core;
using BikeAuctionIntegration.Core.Mapper.DTOs.Bike.Response;
using Microsoft.Extensions.Configuration;

namespace BikeAuctionIntegration.BL.Services.Bike;

public class BikeService(IConfiguration configuration) : IBikeService
{
    public async Task<HandlerResult<BikeResponse>> GetBikesAsync(string? bikeContainerId, CancellationToken cancellationToken)
    {
        var relativeFilePath = configuration.GetValue<string>("BikeData:FilePath");
        var absoluteFilePath = Path.Combine(Directory.GetCurrentDirectory(), relativeFilePath ?? string.Empty);

        if (!File.Exists(absoluteFilePath))
            return HandlerResult<BikeResponse>.Fail("Something went wrong");
        
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        
        var jsonData = await File.ReadAllTextAsync(absoluteFilePath, cancellationToken);
        var bikes = JsonSerializer.Deserialize<BikeResponse>(jsonData, options)?.Values ?? [];

        if (bikeContainerId == null) return HandlerResult.Success(MapToBikeResponse(bikes));

        var bikesOfContainer = bikes.FindAll(c => c.BikeContainerId == bikeContainerId);
        return HandlerResult<BikeResponse>.Success(MapToBikeResponse(bikesOfContainer));
    }

    private BikeResponse MapToBikeResponse(List<Domain.Bike> bikes)
    {
        return new BikeResponse
        {
            Values = bikes,
            ContinuationToken = "1"
        };
    }
}