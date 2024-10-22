using BikeAuctionIntegration.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BikeAuctionIntegration.Api.Controllers;

public class CustomBaseController : ControllerBase
{
    public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object? error)
    {
        var errorResponse = new ProblemDetails();
        if (error is HandlerResult handlerResult)
        {
            errorResponse.Type = "Bad Request";
            errorResponse.Title = handlerResult.Message;
            errorResponse.Status = StatusCodes.Status400BadRequest;
            errorResponse.Detail = handlerResult.Detail;
        }
        else
        {
            errorResponse.Title = error?.ToString() ?? "Bad Request";
            errorResponse.Status = StatusCodes.Status400BadRequest;
        }

        errorResponse.Instance = HttpContext.Request.Path;

        return base.BadRequest(errorResponse);
    }

    public override NotFoundObjectResult NotFound([ActionResultObjectValue] object? error)
    {
        var errorResponse = new ProblemDetails();
        if (error is HandlerResult handlerResult)
        {
            errorResponse.Type = "Not Found";
            errorResponse.Title = handlerResult.Message;
            errorResponse.Status = StatusCodes.Status404NotFound;
            errorResponse.Instance = HttpContext.Request.Path;
            errorResponse.Detail = handlerResult.Detail;
        }
        else
        {
            errorResponse.Title = error?.ToString() ?? "Not Found";
            errorResponse.Status = StatusCodes.Status404NotFound;
            errorResponse.Instance = HttpContext.Request.Path;
        }

        return base.NotFound(errorResponse);
    }

    public override ConflictObjectResult Conflict(object? error)
    {
        var errorResponse = new ProblemDetails();
        if (error is HandlerResult handlerResult)
        {
            errorResponse.Type = "Conflict";
            errorResponse.Title = handlerResult.Message;
            errorResponse.Status = StatusCodes.Status409Conflict;
            errorResponse.Instance = HttpContext.Request.Path;
            errorResponse.Detail = handlerResult.Detail;
        }
        else
        {
            errorResponse.Title = error?.ToString() ?? "Conflict";
            errorResponse.Status = StatusCodes.Status409Conflict;
            errorResponse.Instance = HttpContext.Request.Path;
        }

        return base.Conflict(errorResponse);
    }

    [NonAction]
    public ActionResult Forbid(HandlerResult error)
    {
        return Problem(type: "Forbidden", title: error.Message, statusCode: StatusCodes.Status403Forbidden, detail: error.Detail, instance: HttpContext.Request.Path);
    }

    protected ActionResult CreateResult<T>(HandlerResult<T> handlerResult)
        where T : class
    {
        return handlerResult.Status switch
        {
            HandlerResultStatus.Success => Ok(handlerResult.Result),
            HandlerResultStatus.NotFound => NotFound(handlerResult),
            HandlerResultStatus.Failed => BadRequest(handlerResult),
            HandlerResultStatus.Conflict => Conflict(handlerResult),
            HandlerResultStatus.Forbidden => Forbid(handlerResult),

            _ => throw new NotImplementedException(),
        };
    }

    protected ActionResult CreateResult(HandlerResult handlerResult)
    {
        return handlerResult.Status switch
        {
            HandlerResultStatus.Success => NoContent(),
            HandlerResultStatus.NotFound => NotFound(handlerResult),
            HandlerResultStatus.Failed => BadRequest(handlerResult),
            HandlerResultStatus.Forbidden => Forbid(handlerResult),
            HandlerResultStatus.Conflict => Conflict(handlerResult),
            _ => throw new NotImplementedException(),
        };
    }
}