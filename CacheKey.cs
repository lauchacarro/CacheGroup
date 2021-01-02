namespace CacheGroup
{
    public record CacheKey
    {
        public CacheKey(string method, string parameter, params string[] entities)
        {
            Method = method;
            Parameter = parameter;
            Entities = entities;
        }

        public string Method { get; init; }
        public string Parameter { get; init; }
        public ArrayEquatable<string> Entities { get; init; }
    }
}
