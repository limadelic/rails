﻿namespace Rails;

public static class Return
{
    public static Result Result(bool ok, string message) => ok ? Ok : Error(message);
    public static Result Ok => new Ok();
    public static Result Error(string message) => new Error(message);
}

public static class Return<T>
{
    // public static Result Result(bool ok, string message) => ok ? Ok : Error(message);
    public static Result<T> Ok(T value) => new Ok<T>(value);
    // public static Result Error(string message) => new Error(message);
}