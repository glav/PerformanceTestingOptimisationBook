using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonDataLayer;

namespace WithDataBinding
{
    public partial class _Default : System.Web.UI.Page
    {
        private DataContainer _container = DataManager.GetData("Using Databinding");

        protected override void OnPreRender(EventArgs e)
        {
            rpt1.DataSource = _container.Items;
            DataBind();

            base.OnPreRender(e);
        }


        public string BodyTitle { get { return _container.Title; } }
        public string Comments { get { return _container.Comments; } }
        public string Version { get { return _container.VersionText; } }
    }
}
