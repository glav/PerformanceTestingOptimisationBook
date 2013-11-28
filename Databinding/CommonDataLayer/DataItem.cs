using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDataLayer
{
    public class DataItem
    {
        private Random _rnd = new Random(DateTime.Now.Millisecond);
        
        public string AuthorName { get; set; }
        public string BookTitle { get; set; }
        public DateTime ReleaseDate
        {
            get
            {
                return DateTime.Now.AddMonths(_rnd.Next(1, 100) * -1);
            }
        }
        public string ItemColor
        {
            get
            {

                return string.Format("color:{0}", ((BookColor)_rnd.Next(0, 4)).ToString());
            }
        }
    }

    public enum BookColor
    {
        Green=1,
        Blue=2,
        Purple=3
    }
}
