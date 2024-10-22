using BikeAuctionIntegration.BL.Services.Bike;
using BikeAuctionIntegration.Core.Mapper.DTOs.Bike.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BikeAuctionIntegration.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class BikesController(IBikeService bikeService): CustomBaseController
{
    [HttpGet]
    public async Task<ActionResult<List<BikeResponse>>> GetBikes([FromQuery] string bikeContainerId, CancellationToken cancellationToken)
    {
        // TODO: Map
        var bikes = await bikeService.GetBikesAsync(bikeContainerId, cancellationToken);
        return CreateResult(bikes);
    }
}