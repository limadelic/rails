namespace Rails;

public interface Result
{
    Result<T> With<T>(T value);
    
    Result Do(Action action) => this;

    Result If(Func<bool> condition, string message) => this;
    
    Result Var<T>(out T variable, Func<T> value);
}

public interface Result<T> : Result
{
    new Result<TT> With<TT>(TT value);

    Result<T> Do(Func<T, T> action) => this;

    Result<T> If(Func<T, bool> condition, string message) => this;
    
    Result<T> Var(out T variable);
}