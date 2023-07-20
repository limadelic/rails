namespace Rails.Result;

public class Error : Result
{
    public string Message { get; }

    public Error(string message = null!)
    {
        Message = message;
    }

    public Result<T> Value<T>(T value) =>
        new Error<T>(Message);

    public Result Action(Action action) => this;

    public Result<T> Func<T>(Func<T> function) =>
        new Error<T>(Message);


    public Result NotIf(Func<bool> condition, string message) => this;
}

public class Error<T> : Error, Result<T>
{
    public Error(string message = null!) : base(message) {}

    public Result<T> Value(out T value)
    {
        value = default!;
        return this;
    }

    public Result<T> Action(Action<T> action) => this;

    public Result<TT> Func<TT>(Func<T, TT> function) => 
        new Error<TT>(Message);

    public Result<T> NotIf(Func<T, bool> condition, string message) => this;
}