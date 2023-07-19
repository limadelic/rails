namespace Rails;

public class Error : Result
{
    public string Message { get; }

    public Error(string message = null!)
    {
        Message = message;
    }

    public Result<T> ㅣㅣ<T>(T value) =>
        new Error<T>(Message);

    public Result ㅣㅣ(Action action) => this;

    public Result<T> ㅣㅣ<T>(Func<T> function) =>
        new Error<T>(Message);


    public Result Ⅱ_Ɂ_Ⅱ(Func<bool> condition, string message) => this;
}

public class Error<T> : Error, Result<T>
{
    public Error(string message = null!) : base(message) {}

    public Result<T> ㅣㅣ(out T value)
    {
        value = default!;
        return this;
    }

    public Result<T> ㅣㅣ(Action<T> action) => this;

    public Result<TT> ㅣㅣ<TT>(Func<T, TT> function) => 
        new Error<TT>(Message);

    public Result<T> ㅣɁ(Func<T, bool> condition, string message) => this;
}