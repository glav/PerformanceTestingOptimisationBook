using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;

namespace DataLayer
{
    public static class CacheManager
    {
        public static void FillCache(int expiryTimeInSeconds)
        {
            var data = GetDataFromStore();
            if (System.Web.HttpContext.Current != null)
            {
                System.Web.HttpContext.Current.Cache.Add("TheData", data, null,
                        DateTime.Now.AddSeconds(expiryTimeInSeconds),
                        Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            }

        }

        public static ModelContainer GetData()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            ModelContainer data = null;
            if (System.Web.HttpContext.Current != null)
            {
                data = System.Web.HttpContext.Current.Cache["TheData"] as ModelContainer;
                if (data != null)
                    data.SourceOfData = SourcesOfData.Cache;
                else
                    data = GetDataFromStore();
            }

            watch.Stop();
            data.QueryTime = watch.Elapsed;

            return data;
        }

        private static ModelContainer GetDataFromStore()
        {
            // Simulate some long DB activity
            Random rnd = new Random(DateTime.Now.Millisecond);
            System.Threading.Thread.Sleep(rnd.Next(1, 5) * 1000);

            var data = new ModelContainer();
            data.SourceOfData = SourcesOfData.DataStore;
            data.DataItems.Add(new Model() { Description = "Some Descriptive Text", InstanceTime = DateTime.Now });
            data.DataItems.Add(new Model() { Description = "More Descriptions", InstanceTime = DateTime.Now });
            data.DataItems.Add(new Model() { Description = "Blah Blah Blah", InstanceTime = DateTime.Now });

            return data;
        }
    }
}
