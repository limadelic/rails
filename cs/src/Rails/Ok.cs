namespace Rails;

public class Ok : Result
{
    public Result<T> And<T>(T value) => 
        new Ok<T>(value);

    public Result And(Action action)
    {
        action();
        return this;
    }

    public Result<T> And<T>(Func<T> function) =>
        new Ok<T>(function());

    public Result Not(Func<bool> condition, string message = null!) =>
        condition() ? new Error(message) : this;
}

public class Ok<T> : Ok, Result<T>
{
    public T Value { get; }

    public Ok(T value)
    {
        Value = value;
    }

    public Result<T> And(out T value)
    {
        value = Value;
        return this;
    }

    public Result<T> And(Action<T> action)
    {
        action(Value);
        return this;
    }

    public Result<TT> And<TT>(Func<T, TT> function) =>
        new Ok<TT>(function(Value));

    public Result<T> Not(Func<T, bool> condition, string message = null!) =>
        condition(Value) ? new Error<T>(message) : this;
}