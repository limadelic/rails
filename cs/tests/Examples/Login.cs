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
            
        Rail.ㅣ__ㅣ
            .ㅣ__ㅣ(user)
            .ㅣ__ㅣɁ(string.IsNullOrWhiteSpace, Name.Required)
            .ㅣ__ㅣ(user => user.Trim())
            .ㅣ__ㅣɁ(user => user.Length < MinLength, Name.MinLength)
            .ㅣ__ㅣɁ(user => user.Length > MaxLength, Name.MaxLength)
            .ㅣ__ㅣ(out User)
            .ㅣ__ㅣ(pass)
            .ㅣ__ㅣɁ(pass => pass is null, Password.Required)
            .ㅣ__ㅣɁ(pass => pass.Length < MinLength, Password.MinLength)
            .ㅣ__ㅣɁ(pass => pass.Length > MaxLength, Password.MaxLength)
            .ㅣ__ㅣ(out Pass);
    
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

