namespace Rails;

public interface Result
{
    Result Do(Action action);
    Result<T> Do<T>(T value);
    Result<T> Do<T>(Func<T> function);
    
    Result Not(Func<bool> condition, string message);
}

public interface Result<T> : Result
{
    Result<T> Do(Action<T> action);
    Result<T> Do(out T value);
    Result<To> Do<To>(Func<T, To> function);
    
    Result<T> Not(Func<T, bool> condition, string message);
}
