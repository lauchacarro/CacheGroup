
using Microsoft.Extensions.Caching.Memory;

using System.Collections.Generic;

namespace CacheGroup
{
    public interface IMemoryKeyCache : IMemoryCache
    {
        ICollection<object> GetKeys();
    }
}
