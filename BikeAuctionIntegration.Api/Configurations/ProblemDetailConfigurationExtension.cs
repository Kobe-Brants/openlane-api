using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;

namespace BikeAuctionIntegration.Api.Configurations;

public static class ProblemDetailConfigurationExtension
{
    public static void ConfigureProblemDetail(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        
        services.AddProblemDetails(configure =>
        {
            configure.Map<Exception>(exception => new ProblemDetails
            {
                Type = "Internal Server Error",
                Detail = exception.StackTrace,
                Title = exception.Message,
                Status = StatusCodes.Status500InternalServerError,
            });
        });
    }
}