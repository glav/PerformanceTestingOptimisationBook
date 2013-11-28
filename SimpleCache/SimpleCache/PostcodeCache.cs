using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCache
{
    public static class PostcodeCache
    {
        private static Dictionary<int, string> _postcodes = new Dictionary<int, string>();

        static PostcodeCache()
        {
            LoadPostcodes();
        }

        private static void LoadPostcodes()
        {
            // Typically load from th database or datastore here....
            _postcodes.Add(2000, "Sydney");
            _postcodes.Add(3000, "Melbourne");
            _postcodes.Add(4000, "Brisbane");
        }

        public static string GetPostcode(int postcode)
        {
            if (_postcodes.ContainsKey(postcode))
                return _postcodes[postcode];
            else
                return null;
        }
    }
}
