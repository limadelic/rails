namespace Rails;

public class Ok : Result
{
    public Result<T> With<T>(T value) => Return<T>.Ok(value);

    public Result Do(Action action)
    {
        action();
        return this;
    }

    public Result If(Func<bool> condition, string message) => 
        Return.Result(condition(), message);
}

public class Ok<T> : Ok, Result<T>
{
    public T Value { get; }

    public Ok(T value)
    {
        Value = value;
    }
}