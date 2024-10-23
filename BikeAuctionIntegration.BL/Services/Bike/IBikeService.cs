using BikeAuctionIntegration.Core;
using BikeAuctionIntegration.Core.Mapper.DTOs.Bike.Response;

namespace BikeAuctionIntegration.BL.Services.Bike;

public interface IBikeService
{
    public Task<HandlerResult<BikeResponse>> GetBikesAsync(string? bikeContainerId, CancellationToken cancellationToken);
}