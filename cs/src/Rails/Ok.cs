namespace Rails;

public class Ok : Result
{
    public override Result Do(Action action)
    {
        action();
        return this;
    }

    public override Result If(Func<bool> condition, string message) => 
        Return.Result(condition(), message);
}