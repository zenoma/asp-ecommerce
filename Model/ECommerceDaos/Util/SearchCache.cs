using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceDaos.Util
{
    public class SearchCache<T>
    {
        private const int MAX_NUM_QUERIES_CACHE = 5;

        private MemoryCache queueCache = MemoryCache.Default;

        private Queue<MemoryCache> queue { get; set; }

        public SearchCache()
        {
            initialize();
        }

        private void initialize()
        {
            CacheItem cache = queueCache.GetCacheItem("queue");
            if (cache == null)
            {
                queue = new Queue<MemoryCache>();
                queueCache.Add("queue", queue, DateTimeOffset.MaxValue);
            } else
            {
                queue = (Queue<MemoryCache>) cache.Value;
            }
        }

        public void setQueryOnCache<T>(string title, Block<T> result) where T : class
        {
            initialize();
            MemoryCache memCache = MemoryCache.Default;
            if (queue.Count >= MAX_NUM_QUERIES_CACHE)
            {
                queue.Dequeue();
            }
            memCache.Add(title, result, DateTimeOffset.UtcNow.AddHours(1));
            queue.Enqueue(memCache);
        }

        public Block<T> getQueryFromCache<T>(string title) where T : class
        {
            initialize();
            foreach (MemoryCache item in queue)
            {
                if (item.GetCacheItem(title) != null)
                {
                    return (Block<T>)item.GetCacheItem(title).Value;
                }
            }

            return null;
        }

        public void clearCache()
        {
            if (queueCache != null)
            {
                queueCache.Dispose();
            }
        }
    }
}
