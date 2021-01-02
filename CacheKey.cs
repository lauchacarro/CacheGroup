namespace CacheGroup
{
    public record CacheKey(string Method, string Parameter = "", params string[] Entities);
}
