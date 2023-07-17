namespace Rails;

public class Ok : Result
{
    public override Result Unless(Func<bool> condition, string message) => 
        Return.Result(!condition(), message);

    public override Result Do(Action action)
    {
        action();
        return this;
    }
}