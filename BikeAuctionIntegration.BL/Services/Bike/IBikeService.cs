using BikeAuctionIntegration.Core;

namespace BikeAuctionIntegration.BL.Services.Bike;

public interface IBikeService
{
    public Task<HandlerResult<List<Domain.Bike>>> GetBikesAsync(string? bikeContainerId, CancellationToken cancellationToken);
}