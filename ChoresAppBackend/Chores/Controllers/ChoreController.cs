using ChoresAppBackend.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace ChoresAppBackend.Chores.Controllers;

public class ChoreController : Controller
{
    [HttpGet("chores/{choreId}")]
    public Chore GetChoreById(int choreId)
    {
        using var repo = new ChoreRepository();
        
        return repo.GetChoreById(choreId);
    }

    [HttpPost("chores")]
    public Chore PostChore([FromBody]Chore chore)
    {
        using var repo = new ChoreRepository();

        if (chore.Id == 0)
        {
            return repo.InsertChore(chore);
        }
        
        throw new NotImplementedException();
    }
}