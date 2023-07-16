namespace Rails;

public static class Return
{
    public static Result Ok => new Ok();
    public static Result Error(string message) => new Error(message);
}

public abstract class Result : IRailway
{
    public Result When(Func<bool> condition, string message) => 
        condition() ? Return.Ok : Return.Error(message);

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
