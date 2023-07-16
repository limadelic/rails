namespace Unit;

public class Login
{
    string? User { get; set; }
    string? Pass { get; set; }

    Result SetCreds(string? user, string pass) 
        => Return.Ok
            .When(() => user is not null, "user is required")
            .Then(() => User = user)
            .Then(() => Pass = pass);
    
    [Test]
    public void HappyPath()
    {
        SetCreds("neo", "53CR3T")
            .Should().BeOk();
        
        User.Should().Be("neo");
        Pass.Should().Be("53CR3T");
    }

    [TestCase(null, null, "user is required")]
    public void SadPath(string user, string pass, string error)
    {
        SetCreds(user, pass)
            .Should().BeError(error);
    }

}