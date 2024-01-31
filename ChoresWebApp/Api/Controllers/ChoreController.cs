using System.ComponentModel.DataAnnotations;
using ChoresWebApp.Api.DataAccess;
using ChoresWebApp.Chores;
using Microsoft.AspNetCore.Mvc;

namespace ChoresWebApp.Api.Controllers;

[ApiController]
[Route("chores")]
public class ChoreController(IConfiguration config) : Controller
{
    private readonly ChoreRepository Repo = new(config);
    
    [HttpGet("{choreId:int}")]
    [ProducesResponseType<Chore>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetChoreById(uint choreId)
    {
        var result = Repo.Get(choreId);

        return result.ResultType switch
        {
            RepositoryResultType.Success => Ok(result.Value),
            RepositoryResultType.NoResult => NotFound(new { message = result.Message }),
            _ => BadRequest()
        };
    }

    [HttpPost]
    [ProducesResponseType<Chore>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PostChore([FromBody] Chore chore)
    {
        if (chore.Id == 0)
        {
            return Ok(Repo.Insert(chore).Value);
        }
        
        throw new NotImplementedException();
    }

    [HttpDelete("{choreId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult DeleteChore(int choreId)
    {
        var repoResult = Repo.Delete(choreId);
        
        return repoResult.ResultType switch
        {
            RepositoryResultType.Success => Ok(),
            RepositoryResultType.NoResult => NotFound(new { message = repoResult.Message }),
            _ => BadRequest()
        };
    }
}