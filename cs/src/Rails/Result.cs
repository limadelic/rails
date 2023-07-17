namespace Rails;

public abstract class Result : IRailway
{
    public virtual Result<T> With<T>(T value) => this;
    
    public virtual Result Do(Action action) => this;

    public virtual Result If(Func<bool> condition, string message) => this;
}

public abstract class Result<T> : Result
{
    public virtual Result<T> With(T value) => this;

    public virtual Result<T> Do(Func<T, T> action) => this;

    public virtual Result<T> If(Func<T, bool> condition, string message) => this;
}