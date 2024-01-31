using System.ComponentModel.DataAnnotations;
using ChoresWebApp.Api.DataAccess;

namespace ChoresWebApp.Chores;

public record ChoreSchedule : StandardCrud
{
    [Required]
    public uint ChoreId { get; init; }
    public DateOnly Begins { get; init; }
    public DateOnly Ends { get; init; }
    public string CronExpression { get; init; } = string.Empty;
}