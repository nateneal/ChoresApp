using Microsoft.Data.SqlClient;
using ChoresAppApi.Chores;

namespace ChoresAppApi.DataAccess;

public class ChoreRepository : IChoreRepository
{
    private readonly IDbContext _dbCtx;

    public ChoreRepository(IDbContext dbCtx)
    {
        this._dbCtx = dbCtx;
    }

    public Chore GetChoreById(int id)
    {
        using var connection = new SqlConnection("data source=naten;initial catalog=master;trusted_connection=true");

        connection.Open();
        
        return new Chore();
    }

    public Chore InsertChore(Chore chore)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}