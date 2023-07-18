namespace Rails;

public static class Return
{
    public static Result<T> Result<T>(T value, bool ok, string message = null!) => 
        ok ? Ok(value) : Error(value, message);
    
    public static Result<T> Ok<T>(T value) => 
        new Ok<T>(value);
    
    public static Result<T> Error<T>(T value = default!, string message = null!) => 
        new Error<T>(value, message);
}