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
            
        Pipe.ㅣㅣ
            .ㅣㅣ(user)
            .ㅣɁ(string.IsNullOrWhiteSpace, Name.Required)
            .ㅣㅣ(user => user.Trim())
            .ㅣɁ(user => user.Length < MinLength, Name.MinLength)
            .ㅣɁ(user => user.Length > MaxLength, Name.MaxLength)
            .ㅣㅣ(out User)
            .ㅣㅣ(pass)
            .ㅣɁ(pass => pass is null, Password.Required)
            .ㅣɁ(pass => pass.Length < MinLength, Password.MinLength)
            .ㅣɁ(pass => pass.Length > MaxLength, Password.MaxLength)
            .ㅣㅣ(out Pass);
    
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

