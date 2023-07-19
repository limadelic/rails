namespace Rails;

public class Error : Result
{
    public string Message { get; }

    public Error(string message = null!)
    {
        Message = message;
    }

    public Result<T> Ⅱ___Ⅱ<T>(T value) =>
        new Error<T>(Message);

    public Result Ⅱ___Ⅱ(Action action) => this;

    public Result<T> Ⅱ___Ⅱ<T>(Func<T> function) =>
        new Error<T>(Message);


    public Result Ⅱ_Ɂ_Ⅱ(Func<bool> condition, string message) => this;
}

public class Error<T> : Error, Result<T>
{
    public Error(string message = null!) : base(message) {}

    public Result<T> Ⅱ___Ⅱ(out T value)
    {
        value = default!;
        return this;
    }

    public Result<T> Ⅱ___Ⅱ(Action<T> action) => this;

    public Result<TT> Ⅱ___Ⅱ<TT>(Func<T, TT> function) => 
        new Error<TT>(Message);

    public Result<T> Ⅱ_Ɂ_Ⅱ(Func<T, bool> condition, string message) => this;
}