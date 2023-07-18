namespace Rails;

public class Ok : Result
{
    public Result<T> Do<T>(T value) => 
        new Ok<T>(value);

    public Result Do(Action action)
    {
        action();
        return this;
    }

    public Result<T> Do<T>(Func<T> function) =>
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

    public Result<T> Do(out T value)
    {
        value = Value;
        return this;
    }

    public Result<T> Do(Action<T> action)
    {
        action(Value);
        return this;
    }

    public Result<TT> Do<TT>(Func<T, TT> function) =>
        new Ok<TT>(function(Value));

    public Result<T> Not(Func<T, bool> condition, string message = null!) =>
        condition(Value) ? new Error<T>(message) : this;
}