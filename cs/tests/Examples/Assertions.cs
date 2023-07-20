namespace Examples;

using FluentAssertions.Primitives;
using Rails.Result;

public static class Assertions
{
    public static void BeOk(this ObjectAssertions assertion)
    {
        var Result = assertion.Subject;
        Result.Should().BeAssignableTo<Ok>((Result as Error)?.Message);
    }

    public static void BeError(this ObjectAssertions assertion, string message)
    {
        var Result = assertion.Subject;
        Result.Should().BeAssignableTo<Error>();
        var Error = (Error)Result;
        Error.Message.Should().Be(message);
    }
}