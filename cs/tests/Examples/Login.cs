namespace Examples;

using Name = Messages.User.Name;
using Password = Messages.User.Pass;

[TestFixture]
public class Login
{
    string User = null!;
    string Pass = null!;

    readonly int MaxLength = 6;
    readonly int MinLength = 3; 
    
    Result SetCreds(string user, string pass) => 
            
        Return.Ok
            .Ⅱ___Ⅱ(user)
            .Ⅱ_Ɂ_Ⅱ(string.IsNullOrWhiteSpace, Name.Required)
            .Ⅱ___Ⅱ(user => user.Trim())
            .Ⅱ_Ɂ_Ⅱ(user => user.Length < MinLength, Name.MinLength)
            .Ⅱ_Ɂ_Ⅱ(user => user.Length > MaxLength, Name.MaxLength)
            .Ⅱ___Ⅱ(out User)
            .Ⅱ___Ⅱ(pass)
            .Ⅱ_Ɂ_Ⅱ(pass => pass is null, Password.Required)
            .Ⅱ_Ɂ_Ⅱ(pass => pass.Length < MinLength, Password.MinLength)
            .Ⅱ_Ɂ_Ⅱ(pass => pass.Length > MaxLength, Password.MaxLength)
            .Ⅱ___Ⅱ(out Pass);
    
    [SetUp]
    public void SetUp()
    {
        User = Pass = null!;
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

