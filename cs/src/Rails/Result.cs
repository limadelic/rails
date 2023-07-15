namespace Rails;

public class Result<T> : IRailway
{
    private readonly T value;

    private Result(T value) { this.value = value; }

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator T(Result<T> result) => result.value;
}