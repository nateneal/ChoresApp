namespace ChoresAppWebApp.Chores;

public record Chore
{
   public uint Id { get; init; }
   public required string Name { get; init; }
   public string? Description { get; init; }
}