﻿namespace Rails;

public static class Return
{
    public static Result Ok => new();
}

public static class Return<T>
{
    public static Result<T> Ok(T value) => new(value);
    public static Result<T> Error(T value) => new(value, false);
}

public class Result : IRailway
{
    public bool Ok { get; }

    public Result(bool ok = true)
    {
        Ok = ok;
    }

    public static implicit operator Result(bool ok) => new(ok);
    public static implicit operator bool(Result result) => result.Ok;
    
    public Result Then(Action action)
    {
        action();
        return this;
    }
}

public class Result<T> : Result
{

    private readonly T value;
    private Result<T>? Fail => Ok ? null : this;

    public Result(T value, bool ok = true) : base(ok)
    {
        this.value = value;
    }

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator T(Result<T> result) => result.value;

    public Result<T> When(Func<T, bool> filter) => Fail ?? 
        (filter(value) ? Return<T>.Ok(value) : Return<T>.Error(value));
}

public static class Extensions
{
    public static Result<T> When<T>(this T value, Func<T, bool> filter) => 
        Return<T>.Ok(value).When(filter);
}