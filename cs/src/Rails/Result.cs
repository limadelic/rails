namespace Rails;

public interface Result
{
    Result<T> And<T>(T value);
    
    Result And(Action action);
    
    Result<T> And<T>(Func<T> function);
    
    Result Not(Func<bool> condition, string message = null!);
}

public interface Result<T> : Result
{
    Result<T> And(out T value);
    
    Result<T> And(Action<T> action);
    
    Result<TT> And<TT>(Func<T, TT> function);
    
    Result<T> Not(Func<T, bool> condition, string message = null!);
}
