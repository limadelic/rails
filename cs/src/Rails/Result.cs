namespace Rails;

public abstract class Result : IRailway
{
    public virtual Result Do(Action action) => this;

    public virtual Result Unless(Func<bool> condition, string message) => this;
    public virtual Result Or(Func<bool> condition, string message) => this;
}