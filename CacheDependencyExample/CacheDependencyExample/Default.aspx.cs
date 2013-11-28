using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace CacheDependencyExample
{
    public partial class _Default : System.Web.UI.Page
    {
        public _Default()
        {
            DataContainer = new ModelContainer();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public ModelContainer DataContainer { get; set; }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            GetDataAndSetContainer();
        }

        private void GetDataAndSetContainer()
        {
            DataContainer = CacheManager.GetData();
            rptData.DataSource = DataContainer.DataItems;
        }

        protected void btnFillCache_Click(object sender, EventArgs e)
        {
            int timeInSeconds;
            if (!int.TryParse(txtExpiryTime.Text,out timeInSeconds))
                timeInSeconds = 5;
            CacheManager.FillCache(timeInSeconds);
            GetDataAndSetContainer();
        }

        protected override void OnPreRender(EventArgs e)
        {
            DataBind();
            base.OnPreRender(e);
        }
    }
}
