using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LukeVo.Faith.MainWebsite.Models
{
    public class CachableApi<TKey, TResult>
    {

        protected ConcurrentDictionary<TKey, CachableApiResult<TResult>> Cache { get; set; } = new ConcurrentDictionary<TKey, Models.CachableApiResult<TResult>>();
        public int ResultLifeTime { get; set; }

        public CachableApi(int resultLifeTime)
        {
            this.ResultLifeTime = resultLifeTime;
        }

        public TResult GetOrRequest(TKey key, Func<TResult> request)
        {
            if (Cache.TryGetValue(key, out var result) && !result.Expired(this.ResultLifeTime))
            {
                // Do nothing, use the cache
            }
            else
            {
                var freshResult = request();
                result = new CachableApiResult<TResult>()
                {
                    Result = freshResult,
                };

                Cache[key] = result;
            }

            return result.Result;
        }

        public async Task<TResult> GetOrRequestAsync(TKey key, Func<Task<TResult>> request)
        {
            if (Cache.TryGetValue(key, out var result) && !result.Expired(this.ResultLifeTime))
            {
                // Do nothing, use the cache
            }
            else
            {
                var freshResult = request();
                result = new CachableApiResult<TResult>()
                {
                    Result = await freshResult,
                };

                Cache[key] = result;
            }

            return result.Result;
        }

    }

    public class CachableApiResult<T>
    {

        public T Result { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

        public bool Expired(int lifeTimeInSecond)
        {
            return DateTime.UtcNow > this.CreatedTime.AddSeconds(lifeTimeInSecond);
        }

    }
}
