namespace ChoresWebApp.Api.DataAccess;

public class RepositoryResult<T> : RepositoryResult
{
    public T? Value { get; init; }
}

public class RepositoryResult
{
    public RepositoryResultType ResultType;
    public string Message { get; init; } = string.Empty;
}

public enum RepositoryResultType
{
    Error,
    Success,
    NoResult,
    Unauthorized
}