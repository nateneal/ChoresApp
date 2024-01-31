using ChoresWebApp.Chores;
using Microsoft.Data.SqlClient;

namespace ChoresWebApp.Api.DataAccess;

public class ScheduleRepository : IRepository<ChoreSchedule>
{
    private readonly SqlConnection Connection;

    public ScheduleRepository(IConfiguration config)
    {
        Connection = new SqlConnection(config.GetConnectionString("choresDb"));
        Connection.Open();
    }
    
    public RepositoryResult<ChoreSchedule> Get(uint id)
    {
        const string sql = "SELECT * FROM Chore.dbo.Chores WHERE Id = @Id";
        return Connection.GetSingleItemById<ChoreSchedule>(sql, id);
    }

    public RepositoryResult<ChoreSchedule> Insert(ChoreSchedule? schedule)
    {
        const string sql =
            "INSERT INTO Chore.dbo.Schedules (ChoreId, Begins, Ends, CronExpression) VALUES (@choreId, @begins, @ends, @cronExpr)";

        return Connection.InsertItem<ChoreSchedule>(sql, schedule,
            new { schedule?.ChoreId, schedule?.Begins, schedule?.Ends, schedule?.CronExpression });
    }

    public RepositoryResult Delete(int id)
    {
        throw new NotImplementedException();
    }

    public RepositoryResult Update(ChoreSchedule schedule)
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
    }
}