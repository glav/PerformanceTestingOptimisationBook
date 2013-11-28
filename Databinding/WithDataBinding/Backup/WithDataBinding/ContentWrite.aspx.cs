using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CommonDataLayer;

namespace WithDataBinding
{
    public partial class ContentWrite : System.Web.UI.Page
    {
        private DataContainer _container = DataManager.GetData("Using literal content writing");

        public string HtmlContent
        {
            get { return GetContent(); }
        }

        private string GetContent()
        {
            StringBuilder content = new StringBuilder();
            content.AppendFormat("<div><label>Title:&nbsp;</label><label>{0}</label>", _container.Title);
            content.AppendFormat("<label>Version:&nbsp;</label><span>{0}</span>", _container.VersionText);
            content.AppendFormat("<p>{0}</p></div>", _container.Comments);
            content.Append("<ul>");
            foreach (var item in _container.Items)
            {
                content.AppendFormat("<li style='{0}'>", item.ItemColor);
                content.AppendFormat("<span>Author:</span><span>{0}</span>", item.AuthorName);
                content.AppendFormat("<span>Book:</span><span>{0}</span></li>", item.BookTitle);
            }
            content.Append("</ul>");
            return content.ToString();
        }
    }
}
