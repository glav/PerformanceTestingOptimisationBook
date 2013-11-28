using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public enum SourcesOfData
    {
        NoDataLoaded,
        DataStore,
        Cache
    }

    public class ModelContainer
    {
        public ModelContainer()
        {
            DataItems = new List<Model>();
        }

        public TimeSpan QueryTime { get; set; }
        public SourcesOfData SourceOfData { get; set; }
        
        public List<Model> DataItems { get; private set; }
    }

}
