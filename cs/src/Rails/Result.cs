namespace Rails;

public interface Result
{
    Result<T> Ⅱ___Ⅱ<T>(T value);
    
    Result Ⅱ___Ⅱ(Action action);
    
    Result<T> Ⅱ___Ⅱ<T>(Func<T> function);
    
    Result Ⅱ_Ɂ_Ⅱ(Func<bool> condition, string message = null!);
}

public interface Result<T> : Result
{
    Result<T> Ⅱ___Ⅱ(out T value);
    
    Result<T> Ⅱ___Ⅱ(Action<T> action);
    
    Result<TT> Ⅱ___Ⅱ<TT>(Func<T, TT> function);
    
    Result<T> Ⅱ_Ɂ_Ⅱ(Func<T, bool> condition, string message = null!);
}
