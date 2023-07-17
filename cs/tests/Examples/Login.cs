namespace Unit;

using Name = Messages.User.Name;

public class Login
{
    string? User { get; set; }
    string? Pass { get; set; }

    readonly int MaxLength = 5;
    
    Result SetCreds(string? user, string pass) 
        => Return.Ok
            .If(() => user is not null, Name.Required)
            .If(() => user!.Trim().Length <= MaxLength, Name.MaxLength)
            .Do(() => User = user)
            .Do(() => Pass = pass);

    [SetUp]
    public void SetUp()
    {
        User = Pass = null;
    }
    
    [Test]
    public void HappyPath()
    {
        SetCreds("neo", "53CR3T")
            .Should().BeOk();
        
        User.Should().Be("neo");
        Pass.Should().Be("53CR3T");
    }

    [TestCase(null, null, Name.Required)]
    [TestCase("LongName", null, Name.MaxLength)]
    public void SadPath(string user, string pass, string error)
    {
        SetCreds(user, pass)
            .Should().BeError(error);

        User.Should().BeNull();
        Pass.Should().BeNull();
    }

}