namespace Rails;

public static class Result
{
    public static Result<T> Ok<T>(T value) => new(value);
    public static Result<T> Error<T>(T value) => new(value, false);
}

public class Result<T> : IRailway
{
    public bool Ok { get; }

    private readonly T value;
    private Result<T>? Fail => Ok ? null : this;

    public Result(T value, bool ok = true)
    {
        this.value = value;
        Ok = ok;
    }

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator T(Result<T> result) => result.value;

    public Result<T> When(Func<T, bool> filter) => Fail ?? 
        (filter(value) ? Result.Ok(value) : Result.Error(value));
}

public static class Extensions
{
    public static Result<T> When<T>(this T value, Func<T, bool> filter) => 
        Result.Ok(value).When(filter);
}