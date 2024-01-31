using System.Text.Json.Serialization;

namespace ChoresWebApp.Chores;

public abstract record StandardCrud
{
    public uint Id { get; init; }
    [JsonIgnore]
    public bool IsDeleted { get; init; }
}