using ChoresAppBackend.DataAccess;

namespace ChoresAppApiTest.DataAccess;

[TestFixture]
[TestOf(typeof(ChoreRepository))]
public class ChoreRepositoryTest
{

    [Test]
    public void GetChoreByIdTest()
    {
        var choreRepo = new ChoreRepository();
        choreRepo.GetChoreById(1);
    }
}