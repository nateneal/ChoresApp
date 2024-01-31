using ChoresWebApp.Api.DataAccess;
using Microsoft.Extensions.Configuration;

namespace ChoresAppApiTest.DataAccess;

[TestFixture]
[TestOf(typeof(ChoreRepository))]
public class ChoreRepositoryTest
{

    [Test]
    public void GetChoreByIdTest()
    {
        var settings = new Dictionary<string, string>()
        {
            {
                "ConnectionStrings:choresDb",
                "data source=localhost;initial catalog=master;Integrated Security=SSPI;TrustServerCertificate=true"
            }
        };

        IConfigurationRoot config = new ConfigurationManager().AddInMemoryCollection(settings!).Build();
        
        var choreRepo = new ChoreRepository(config);
        var chore = choreRepo.Get(1).Value;
        Assert.That(chore is { Id: 1, Name: "Init Chore" });
    }
}