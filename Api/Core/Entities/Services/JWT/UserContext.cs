namespace Api.Core.Services;

public readonly record struct ContextData
{
    public required int UserId { get; init; }
    public required string Username { get; init; }
}

public class UserContext
{
    private ContextData _data;

    public int UserId => _data.UserId;
    public string Username => _data.Username;

    public void Fill(ContextData data)
    {
        _data = data;
    }
}