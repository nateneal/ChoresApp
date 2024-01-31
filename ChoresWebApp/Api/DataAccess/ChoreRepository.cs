using ChoresWebApp.Chores;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ChoresWebApp.Api.DataAccess;

public class ChoreRepository : IRepository<Chore>
{
    private readonly SqlConnection Connection;

    public ChoreRepository(IConfiguration config)
    {
        Connection = new SqlConnection(config.GetConnectionString("choresDb"));
        Connection.Open();
    }

    public RepositoryResult<Chore> Get(uint id)
    {
        const string sql = "SELECT * FROM Chore.dbo.Chores WHERE Id = @Id";
        return Connection.GetSingleItemById<Chore>(sql, id);
    }

    public RepositoryResult<Chore> Insert(Chore? chore)
    {
        const string sql = "INSERT INTO Chore.dbo.Chores (Name, Description) OUTPUT INSERTED.Id VALUES (@name, @description)";
        var id = Connection.QuerySingle<uint>(sql, new { name = chore!.Name, description = chore.Description });
        
        return new RepositoryResult<Chore>()
        {
            ResultType = RepositoryResultType.Success,
            Value = chore with{ Id = id }
        };
    }

    public RepositoryResult Delete(int id)
    {
        const string sql = "UPDATE Chore.dbo.Chores SET IsDeleted = 1 WHERE Id = @id";
        var affected = Connection.Execute(sql, new { id });

        if (affected == 0)
        {
            return new RepositoryResult
            {
                ResultType = RepositoryResultType.NoResult, 
                Message = "No chore found with the specified ID"
            };
        }
        
        return new RepositoryResult
        {
            ResultType = RepositoryResultType.Success
        };
    }

    public RepositoryResult Update(Chore chore)
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
        Connection.Close();
        Connection.Dispose();
    }
}