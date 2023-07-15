namespace Unit;

public class ResultTests
{
    [Test]
    public void ImplicitOperator()
    {
        ((int)((Result<int>)42)).Should().Be(42);
    }
}