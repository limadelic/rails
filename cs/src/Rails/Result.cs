namespace Rails;

public abstract class Result : IRailway
{
    public virtual Result Unless(Func<bool> condition, string message) => this;
    public virtual Result Do(Action action) => this;
}