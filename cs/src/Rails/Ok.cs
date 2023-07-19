namespace Rails;

public class Ok : Result
{
    public Result<T> ㅣ__ㅣ<T>(T value) => 
        new Ok<T>(value);

    public Result ㅣ__ㅣ(Action action)
    {
        action();
        return this;
    }

    public Result<T> ㅣ__ㅣ<T>(Func<T> function) =>
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

    public Result<T> ㅣ__ㅣ(out T value)
    {
        value = Value;
        return this;
    }

    public Result<T> ㅣ__ㅣ(Action<T> action)
    {
        action(Value);
        return this;
    }

    public Result<TT> ㅣ__ㅣ<TT>(Func<T, TT> function) =>
        new Ok<TT>(function(Value));

    public Result<T> ㅣ__ㅣɁ(Func<T, bool> condition, string message = null!) =>
        condition(Value) ? new Error<T>(message) : this;
}