namespace Rails;

public class Error<T> : Result<T>
{
    public T Value { get; }
    public string Message { get; }

    public Error(T value, string message)
    {
        Value = value;
        Message = message;
    }
}