namespace Unit;

public class When
{
    [Test]
    public void Odd()
    {
        bool IsOdd(int x) => x % 2 == 0;
        
        2.When(IsOdd).Ok.Should().BeTrue();
        1.When(IsOdd).Ok.Should().BeFalse();
    }
}