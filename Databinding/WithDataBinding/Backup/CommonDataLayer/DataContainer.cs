using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDataLayer
{
    public class DataContainer
    {

        public DataContainer()
        {
            Items = new List<DataItem>();
        }

        public string Title { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int Revision { get; set; }
        public string VersionText { get { return string.Format("{0}.{1}.{2}", MajorVersion, MinorVersion, Revision); } }
        public string Comments { get; set; }
        public List<DataItem> Items { get; private set; }
    }
}
