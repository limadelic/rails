namespace Rails;

public class Error : Result
{
    public string Message { get; }

    public Error(string message)
    {
        Message = message;
    }

    public Result<T> With<T>(T value) => 
        Return<T>.Error(value, Message);

    public Result Var<T>(out T variable, Func<T> value)
    {
        variable = default!;
        return this;
    }
}

public class Error<T> : Error, Result<T>
{
    public Error(string message) : base(message)
    {
    }

    public Result<T> Var(out T variable)
    {
        variable = default!;
        return this;
    }
}