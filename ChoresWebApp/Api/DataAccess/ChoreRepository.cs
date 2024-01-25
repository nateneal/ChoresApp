using Microsoft.Data.SqlClient;
using Dapper;
using ChoresAppWebApp.Chores;

namespace ChoresAppWebApp.DataAccess;

public class ChoreRepository : IChoreRepository
{
    public Chore GetChoreById(int id)
    {
        using var connection = new SqlConnection("data source=localhost;initial catalog=master;Integrated Security=SSPI;TrustServerCertificate=true");

        connection.Open();

        var chore = connection.QuerySingle<Chore>("SELECT * FROM Chore.dbo.Chores WHERE Id = @Id", new{ Id = id });
        
        return chore;
    }

    public Chore InsertChore(Chore chore)
    {
        using var connection = new SqlConnection("data source=localhost;initial catalog=master;Integrated Security=SSPI;TrustServerCertificate=true");

        connection.Open();

        string sql = "INSERT INTO Chore.dbo.Chores (Name) OUTPUT INSERTED.Id, INSERTED.Name VALUES (@name)";
        
        var returnChore = connection.QuerySingle<Chore>(sql, new { name = chore.Name });
        
        return returnChore;
    }

    public void DeleteChore(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateChore(Chore chore)
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
        
    }
}