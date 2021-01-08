using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util
{
    public class SearchCache<T>
    {
        private const int MAX_NUM_QUERIES_CACHE = 5;

        private ObjectCache cache = MemoryCache.Default;

        private Queue<string> queue = new Queue<string>();

        public SearchCache()
        {
        }

        public void setQueryOnCache<T>(string title, Block<T> result) where T : class
        {
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(1)
            };


            if (queue.Count >= MAX_NUM_QUERIES_CACHE)
            {
                cache.Remove(queue.Dequeue());
            }

            cache.Add(title, result, cacheItemPolicy);
            queue.Enqueue(title);

            return;
        }

        public Block<T> getQueryFromCache<T>(string title) where T : class
        {

            if (cache.GetCacheItem(title) != null)
            {
                return (Block<T>)cache.Get(title);
            }

            return null;
        }

        public void clearCache()
        {
            foreach(var item in cache)
            {
                cache.Remove(item.Key);
            }
            queue = new Queue<string>();
        }
    }
}
