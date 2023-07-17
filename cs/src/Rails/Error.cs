namespace Rails;

public class Error : Result
{
    public string Message { get; }

    public Error(string message)
    {
        Message = message;
    }

    public Result<T> With<T>(T value) { throw new NotImplementedException(); }
}