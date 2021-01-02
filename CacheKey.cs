namespace WebApi.CachePerEntity.Caching
{
    public record CacheKey(string Method, string Parameter = "", params string[] Entities);
}
