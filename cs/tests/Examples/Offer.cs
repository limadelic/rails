namespace Examples;

using Candidate = Messages.Offer.Candidate;

public class OfferExample
{
    Offer Offer = null!;
    Repo<Person> personRepo = null!;

    Guid candidateId = Guid.NewGuid();
    
    // public Result Accept(Offer offer, Guid candidateId, string? signature = null) =>
    //     
    //     Return.Ok
    //         .With(out var candidate, _ => personRepo.Get(candidateId))
    //         .If(x => x not is null, Candidate.NotFound);

    [SetUp]
    public void SetUp()
    {
        Offer = Substitute.For<Offer>();
        personRepo = Substitute.For<Repo<Person>>();
    }
    
    [Test]
    public void HappyPath()
    {
        // Accept(Offer, candidateId)
            // .Should().BeOk();
    }
}

public interface Offer {}
public interface Person {}
public interface Repo<T> {}
