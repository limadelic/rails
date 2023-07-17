namespace Rails;

public class Ok : Result
{
    public override Result Do(Action action)
    {
        action();
        return this;
    }

    public override Result Unless(Func<bool> condition, string message) => 
        Return.Result(!condition(), message);
    
    public override Result Or(Func<bool> condition, string message) => 
        Unless(condition, message);
}