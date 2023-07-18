namespace Examples;

using Name = Messages.User.Name;
using Password = Messages.User.Pass;

public abstract class Login
{
    protected string? User { get; set; }
    protected string? Pass { get; set; }

    protected readonly int MaxLength = 6;
    protected readonly int MinLength = 3;

    protected abstract Rails.Result SetCreds(string user, string pass);
        
    
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
    [TestCase("I", null, Name.MinLength)]
    [TestCase("LongName", null, Name.MaxLength)]
    [TestCase("neo", null, Password.Required)]
    [TestCase("neo", "X", Password.MinLength)]
    [TestCase("neo", "LongPass", Password.MaxLength)]
    public void SadPath(string user, string pass, string error)
    {
        SetCreds(user, pass)
            .Should().BeError(error);
    }
}

[TestFixture]
public class Flow : Login
{
    protected override Result SetCreds(string user, string pass) => 
            
        Return.Ok
            .If(() => !string.IsNullOrWhiteSpace(user), Name.Required)
            .Do(() => user = user.Trim())
            .If(() => user.Length >= MinLength, Name.MinLength)
            .If(() => user.Length <= MaxLength, Name.MaxLength)
            .If(() => pass is not null, Password.Required)
            .If(() => pass.Length >= MinLength, Password.MinLength)
            .If(() => pass.Length <= MaxLength, Password.MaxLength)
            .Do(() => User = user)
            .Do(() => Pass = pass);
}

[TestFixture]
public class Pipe : Login
{
    protected override Result SetCreds(string user, string pass) => 
            
        Return.Ok
            .With(user)
            .If(user => !string.IsNullOrWhiteSpace(user), Name.Required)
            .Do(user => user.Trim())
            .If(user => user.Length >= MinLength, Name.MinLength)
            .If(user => user.Length <= MaxLength, Name.MaxLength)
            .Do(user => User = user)
            .With(pass)
            .If(pass => pass is not null, Password.Required)
            .If(pass => pass.Length >= MinLength, Password.MinLength)
            .If(pass => pass.Length <= MaxLength, Password.MaxLength)
            .Do(pass => Pass = pass);
}

