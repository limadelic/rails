namespace Rails.Result;

public interface Result
{
    Result<T> Value<T>(T value);
    
    Result Action(Action action);
    
    Result<T> Func<T>(Func<T> function);
    
    Result NotIf(Func<bool> condition, string message = null!);
}

public interface Result<T> : Result
{
    Result<T> Value(out T value);
    
    Result<T> Action(Action<T> action);
    
    Result<TT> Func<TT>(Func<T, TT> function);
    
    Result<T> NotIf(Func<T, bool> condition, string message = null!);
}
