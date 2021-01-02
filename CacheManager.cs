using Microsoft.Extensions.Caching.Memory;

using System;
using System.Threading.Tasks;

namespace CacheGroup
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryKeyCache _memoryCache;

        public CacheManager(IMemoryKeyCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public T GetOrSet<T>(CacheKey cacheKey, Func<T> getItemCallback) where T : class
        {
            if (_memoryCache.Get(cacheKey) is not T item)
            {
                item = getItemCallback();

                _memoryCache.Set(cacheKey, item);
            }

            return item;
        }

        public async Task<T> GetOrSetAsync<T>(CacheKey cacheKey, Func<Task<T>> getItemCallback) where T : class
        {
            if (_memoryCache.Get(cacheKey) is not T item)
            {
                item = await getItemCallback();

                _memoryCache.Set(cacheKey, item);
            }

            return item;
        }

        public void RemoveByEntity(string entity)
        {
            foreach (var key in _memoryCache.GetKeys())
            {
                if (key is CacheKey cacheKey)
                {
                    for (int i = 0; i < cacheKey.Entities.Length; i++)
                    {
                        if (cacheKey.Entities[i] == entity)
                        {
                            _memoryCache.Remove(key);
                            break;
                        }
                    }
                }
            }
        }

        public void RemoveByEntity(params string[] entities)
        {
            foreach (var key in _memoryCache.GetKeys())
            {
                if (key is CacheKey cacheKey)
                {
                    foreach (var entity in cacheKey.Entities)
                    {
                        for (int entityIndex = 0; entityIndex < entities.Length; entityIndex++)
                        {
                            if (entity == entities[entityIndex])
                            {
                                _memoryCache.Remove(key);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
