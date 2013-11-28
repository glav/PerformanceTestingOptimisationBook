using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Data.SqlClient;
using System.Configuration;

namespace SQLCacheDependency
{
    /// <summary>
    /// Script to enable SQL Cache dependency:
    /// aspnet_regsql -t Customer -et -C "Data Source=.;Integrated Security=SSPI;" -d test -ed
    /// </summary>

    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cacheData = Cache["MyRecord"] as DataEntity;
            if (cacheData == null)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select CustomerName from Customer",conn);
                SqlCacheDependency cacheDependency = null;
                try
                {
                    cacheDependency = new SqlCacheDependency("test", "Customer");

                    using (var dc = new DataStoreDataContext(ConfigurationManager.ConnectionStrings["sql"].ConnectionString))
                    {
                        var records = dc.Customers.Take(1);
                        if (records.Count() > 0)
                        {
                            cacheData = new DataEntity() { Name = records.First().CustomerName, RetrievalTime = DateTime.Now };
                            Cache.Insert("MyRecord", cacheData, cacheDependency);
                        }
                    }
                }
                //catch (DatabaseNotEnabledForNotificationException exDBDis)
                //{
                //    try
                //    {
                //        SqlCacheDependencyAdmin.EnableNotifications("test");
                //    }

                //    // If the database does not have permissions set for creating tables, 
                //    // the UnauthorizedAccessException is thrown. Handle it by redirecting 
                //    // to an error page. 
                //    catch (UnauthorizedAccessException exPerm)
                //    {
                //        Response.Redirect(".\\ErrorPage.htm");
                //    }

                //}

            }

            lblName.Text = cacheData.Name;
            lblTime.Text = cacheData.RetrievalTime.ToString("hh:mm:ss");
        }
    }

    public class DataEntity
    {
        public DateTime RetrievalTime { get; set; }
        public string Name { get; set; }
    }
}
