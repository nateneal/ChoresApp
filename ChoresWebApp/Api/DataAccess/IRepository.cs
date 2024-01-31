using ChoresWebApp.Chores;

namespace ChoresWebApp.Api.DataAccess;

public interface IRepository<T> : IDisposable
{
    RepositoryResult<T> Get(uint id);
    RepositoryResult<T> Insert(T? item);
    RepositoryResult Delete(int id);
    RepositoryResult Update(T item);
}