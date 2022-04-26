namespace store.Repositories.Core;

public class PaginatedListQuery
{
    public int Offset { get; set; }

    public int Limit { get; set; } = 20;

    public string SearchKey { get; set; }

    public Dictionary<string, string> Sort { get; set; }
}