namespace BikeAuctionIntegration.Core;

/// <summary>
/// A result, used in the handlers, to indicate success or failure. <br/>
/// It can also contain a message.
/// </summary>
public record HandlerResult(HandlerResultStatus Status, string? Message = null, string? Detail = null)
{
    public static HandlerResult Success()
    {
        return new HandlerResult(HandlerResultStatus.Success);
    }

    public static HandlerResult<T> Success<T>(T result)
        where T : class
    {
        return new HandlerResult<T>(result);
    }

    public static HandlerResult NotFound(string message)
    {
        return new HandlerResult(HandlerResultStatus.NotFound, message);
    }

    public static HandlerResult Fail(string message, string detail)
    {
        return new HandlerResult(HandlerResultStatus.Failed, message, detail);
    }

    public static HandlerResult Forbidden(string message)
    {
        return new HandlerResult(HandlerResultStatus.Forbidden, message);
    }

    public static HandlerResult Conflict(string message)
    {
        return new HandlerResult(HandlerResultStatus.Conflict, message);
    }
}

/// <summary>
/// A result, used in the handlers, to indicate success or failure. <br/>
/// It can also contain a message.
/// </summary>
public record HandlerResult<T> : HandlerResult
    where T : class
{
    public HandlerResult(T result)
        : base(HandlerResultStatus.Success)
    {
        Result = result;
    }

    public HandlerResult(HandlerResultStatus status, string message)
        : base(status, message)
    {
    }

    public HandlerResult(HandlerResultStatus status, string message, string detail)
        : base(status, message, detail)
    {
    }

    public T Result { get; }

    public static HandlerResult<T> Success(T result)
    {
        return new HandlerResult<T>(result);
    }

    public static new HandlerResult<T> NotFound(string message)
    {
        return new HandlerResult<T>(HandlerResultStatus.NotFound, message);
    }

    public static HandlerResult<T> Fail(string message)
    {
        return new HandlerResult<T>(HandlerResultStatus.Failed, message);
    }

    public static new HandlerResult<T> Forbidden(string message)
    {
        return new HandlerResult<T>(HandlerResultStatus.Forbidden, message);
    }

    public static new HandlerResult<T> Conflict(string message)
    {
        return new HandlerResult<T>(HandlerResultStatus.Conflict, message);
    }
}
