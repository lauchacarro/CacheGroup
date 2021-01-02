
using System;
using System.Threading.Tasks;

namespace CacheGroup
{
    public interface ICacheManager
    {
        T GetOrSet<T>(CacheKey cacheKey, Func<T> getItemCallback);
        Task<T> GetOrSetAsync<T>(CacheKey cacheKey, Func<Task<T>> getItemCallback);

        void RemoveByEntity(string entity);
        void RemoveByEntity(params string[] entities);
    }
}
