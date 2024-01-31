using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ChoresWebApp.Api.DataAccess;

namespace ChoresWebApp.Chores;

public record Chore : StandardCrud
{
   [Required]
   [RegularExpression(@"(.|\s)*\S(.|\s)*", ErrorMessage = "Name cannot be empty or whitespace")]
   public string? Name { get; init; }
   public string? Description { get; init; }
}