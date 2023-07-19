namespace Rails;

public interface Result
{
    Result<T> ㅣ__ㅣ<T>(T value);
    
    Result ㅣ__ㅣ(Action action);
    
    Result<T> ㅣ__ㅣ<T>(Func<T> function);
    
    Result Ⅱ_Ɂ_Ⅱ(Func<bool> condition, string message = null!);
}

public interface Result<T> : Result
{
    Result<T> ㅣ__ㅣ(out T value);
    
    Result<T> ㅣ__ㅣ(Action<T> action);
    
    Result<TT> ㅣ__ㅣ<TT>(Func<T, TT> function);
    
    Result<T> ㅣ__ㅣɁ(Func<T, bool> condition, string message = null!);
}
