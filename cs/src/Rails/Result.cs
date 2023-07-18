namespace Rails;

public interface Result
{
    Result<T> Do<T>(T value);
    
    Result Do(Action action);
    
    Result<T> Do<T>(Func<T> function);
    
    Result Not(Func<bool> condition, string message);
}

public interface Result<T> : Result
{
    Result<T> Do(out T value);
    
    Result<T> Do(Action<T> action);
    
    Result<TT> Do<TT>(Func<T, TT> function);
    
    Result<T> Not(Func<T, bool> condition, string message);
}
