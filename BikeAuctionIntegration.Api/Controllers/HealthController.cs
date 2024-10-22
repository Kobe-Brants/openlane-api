using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BikeAuctionIntegration.Api.Controllers;

[AllowAnonymous]
[Route("api/[controller]", Name = "Health")]
[ApiController]
public class HealthController : CustomBaseController
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        return Ok($"version {Assembly.GetExecutingAssembly().GetName().Version}");
    }
}