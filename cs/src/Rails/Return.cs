namespace Rails;

public static class Return
{
    public static Result New(bool ok, string message) => ok ? Ok : Error(message);
    public static Result Ok => new Ok();
    public static Result Error(string message) => new Error(message);
}

public abstract class Result : IRailway
{
    public Result Reject(Func<bool> condition, string message) => 
        Return.New(!condition(), message);

    public Result Then(Action action)
    {
        action();
        return this;
    }
}

public class Ok : Result
{
}

public class Error : Result
{
    public string Message { get; }

    public Error(string message)
    {
        Message = message;
    }
}
