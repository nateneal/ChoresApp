using System.Data.SqlTypes;
using ChoresWebApp.Chores;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChoresWebApp.Api.DataAccess;

public static class SqlExtensions
{
    public static RepositoryResult<T> GetSingleItemById<T>(this SqlConnection conn, string sql, uint id) where T : StandardCrud
    {
        var result = conn.Query<T>(sql, new { Id = id }).FirstOrDefault();

        if (result == null || result.IsDeleted == true)
        {
            return new RepositoryResult<T>
            {
                ResultType = RepositoryResultType.NoResult,
                Value = result,
                Message = "No chore found with the specified ID"
            };
        }
        
        return new RepositoryResult<T>
        {
            ResultType = RepositoryResultType.Success,
            Value = result,
            Message = string.Empty
        };
    }

    public static RepositoryResult<T> InsertItem<T>(this SqlConnection conn, string sql, T? item, object inputValues) where T : StandardCrud
    {
        var id = conn.QuerySingle<uint>(sql, inputValues);
        
        return new RepositoryResult<T>
        {
            ResultType = RepositoryResultType.Success,
            Value = item == null ? null : item with { Id = id }
        };
    }
}