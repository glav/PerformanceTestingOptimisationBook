using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonDataLayer;

namespace WithDataBinding
{
    public partial class MarkupAndResponseWrite : System.Web.UI.Page
    {
        private DataContainer _container = DataManager.GetData("Using markup and response writing");

        public string BodyTitle { get { return _container.Title; } }
        public string Comments { get { return _container.Comments; } }
        public string Version { get { return _container.VersionText; } }
        public List<DataItem> DataItems { get { return _container.Items; } }
    }
}
