using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util
{
    public class SearchCache<T>
    {
        private const int MAX_NUM_QUERIES_CACHE = 5;

        private ObjectCache cache = MemoryCache.Default;

        private Queue<string> queue;

        public SearchCache()
        {
            queue = (Queue<string>) cache.AddOrGetExisting("queue", new Queue<string>(), DateTimeOffset.MaxValue);
            if ( queue == null)
            {
                queue = (Queue<string>) cache.Get("queue");
            }
        }

        public void setQueryOnCache<U>(string title, Block<U> result) where U : class
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
            cache.Set("queue", queue, DateTimeOffset.MaxValue);
        }

        public Block<U> getQueryFromCache<U>(string title) where U : class
        {

            if (cache.GetCacheItem(title) != null)
            {
                return (Block<U>)cache.Get(title);
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
            cache.Set("queue", queue, DateTimeOffset.MaxValue);
        }
    }
}
