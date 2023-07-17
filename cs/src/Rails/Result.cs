namespace Rails;

public interface Result : IRailway
{
    public Result<T> With<T>(T value);
    
    public Result Do(Action action) => this;

    public Result If(Func<bool> condition, string message) => this;
}

public interface Result<T> : Result
{
    public Result<T> With(T value) => this;

    public Result<T> Do(Func<T, T> action) => this;

    public Result<T> If(Func<T, bool> condition, string message) => this;
}