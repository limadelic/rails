namespace Rails;

public class Error : Result
{
    public string Message { get; }

    public Error(string message = null!)
    {
        Message = message;
    }

    public Result<T> ㅣ__ㅣ<T>(T value) =>
        new Error<T>(Message);

    public Result ㅣ__ㅣ(Action action) => this;

    public Result<T> ㅣ__ㅣ<T>(Func<T> function) =>
        new Error<T>(Message);


    public Result Ⅱ_Ɂ_Ⅱ(Func<bool> condition, string message) => this;
}

public class Error<T> : Error, Result<T>
{
    public Error(string message = null!) : base(message) {}

    public Result<T> ㅣ__ㅣ(out T value)
    {
        value = default!;
        return this;
    }

    public Result<T> ㅣ__ㅣ(Action<T> action) => this;

    public Result<TT> ㅣ__ㅣ<TT>(Func<T, TT> function) => 
        new Error<TT>(Message);

    public Result<T> ㅣ__ㅣɁ(Func<T, bool> condition, string message) => this;
}