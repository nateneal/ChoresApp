using ChoresAppBackend.Chores;

namespace ChoresAppBackend.DataAccess;

public interface IChoreRepository : IDisposable
{
    Chore GetChoreById(int id);
    Chore InsertChore(Chore chore);
    void DeleteChore(int id);
    void UpdateChore(Chore chore);
}