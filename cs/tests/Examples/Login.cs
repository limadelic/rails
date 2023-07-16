namespace Unit;

public class Login
{
    string? User { get; set; }
    string? Pass { get; set; }

    Result SetCreds(string user, string pass)
    {
        User = user;
        Pass = pass;

        return true;
    }
    
    [Test]
    public void HappyPath()
    {
        SetCreds("neo", "53CR3T")
            .Should().BeOk();
        
        User.Should().Be("neo");
        Pass.Should().Be("53CR3T");
    }

}