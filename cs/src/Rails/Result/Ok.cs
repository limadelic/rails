namespace Rails.Result;

public class Ok : Result
{
    public Result<T> Value<T>(T value) => 
        new Ok<T>(value);

    public Result Action(Action action)
    {
        action();
        return this;
    }

    public Result<T> Func<T>(Func<T> func) =>
        new Ok<T>(func());

    public Result NotIf(Func<bool> condition, string message = null!) =>
        condition() ? new Error(message) : this;
}

public class Ok<T> : Ok, Result<T>
{
    private T value { get; }

    public Ok(T value)
    {
        this.value = value;
    }

    public Result<T> Value(out T value)
    {
        value = this.value;
        return this;
    }

    public Result<T> Action(Action<T> action)
    {
        action(value);
        return this;
    }

    public Result<TT> Func<TT>(Func<T, TT> func) =>
        new Ok<TT>(func(value));

    public Result<T> NotIf(Func<T, bool> condition, string message = null!) =>
        condition(value) ? new Error<T>(message) : this;
}