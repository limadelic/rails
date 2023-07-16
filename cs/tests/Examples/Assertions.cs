namespace Unit;

using FluentAssertions.Primitives;

public static class Assertions
{
    public static void BeOk(this ObjectAssertions assertion)
    {
        var Result = (Result) assertion.Subject;
        Result.Ok.Should().BeTrue();
    }
}