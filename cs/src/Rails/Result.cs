namespace Rails;

public interface Result
{
    Result<T> ㅣㅣ<T>(T value);
    
    Result ㅣㅣ(Action action);
    
    Result<T> ㅣㅣ<T>(Func<T> function);
    
    Result Ⅱ_Ɂ_Ⅱ(Func<bool> condition, string message = null!);
}

public interface Result<T> : Result
{
    Result<T> ㅣㅣ(out T value);
    
    Result<T> ㅣㅣ(Action<T> action);
    
    Result<TT> ㅣㅣ<TT>(Func<T, TT> function);
    
    Result<T> ㅣɁ(Func<T, bool> condition, string message = null!);
}
