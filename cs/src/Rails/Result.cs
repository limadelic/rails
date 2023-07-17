namespace Rails;

public abstract class Result : IRailway
{
    public virtual Result Do(Action action) => this;

    public virtual Result If(Func<bool> condition, string message) => this;
}