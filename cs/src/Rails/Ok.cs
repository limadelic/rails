namespace Rails;

public class Ok : Result
{
    public Result<T> Ⅱ___Ⅱ<T>(T value) => 
        new Ok<T>(value);

    public Result Ⅱ___Ⅱ(Action action)
    {
        action();
        return this;
    }

    public Result<T> Ⅱ___Ⅱ<T>(Func<T> function) =>
        new Ok<T>(function());

    public Result Ⅱ_Ɂ_Ⅱ(Func<bool> condition, string message = null!) =>
        condition() ? new Error(message) : this;
}

public class Ok<T> : Ok, Result<T>
{
    public T Value { get; }

    public Ok(T value)
    {
        Value = value;
    }

    public Result<T> Ⅱ___Ⅱ(out T value)
    {
        value = Value;
        return this;
    }

    public Result<T> Ⅱ___Ⅱ(Action<T> action)
    {
        action(Value);
        return this;
    }

    public Result<TT> Ⅱ___Ⅱ<TT>(Func<T, TT> function) =>
        new Ok<TT>(function(Value));

    public Result<T> Ⅱ_Ɂ_Ⅱ(Func<T, bool> condition, string message = null!) =>
        condition(Value) ? new Error<T>(message) : this;
}