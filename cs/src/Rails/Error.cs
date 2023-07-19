namespace Rails;

public class Error : Result
{
    public string Message { get; }

    public Error(string message = null!)
    {
        Message = message;
    }

    public Result<T> And<T>(T value) =>
        new Error<T>(Message);

    public Result And(Action action) => this;

    public Result<T> And<T>(Func<T> function) =>
        new Error<T>(Message);


    public Result Not(Func<bool> condition, string message) => this;
}

public class Error<T> : Error, Result<T>
{
    public Error(string message = null!) : base(message) {}

    public Result<T> And(out T value)
    {
        value = default!;
        return this;
    }

    public Result<T> And(Action<T> action) => this;

    public Result<TT> And<TT>(Func<T, TT> function) => 
        new Error<TT>(Message);

    public Result<T> Not(Func<T, bool> condition, string message) => this;
}