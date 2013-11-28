using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Text;

namespace AsyncPages
{
    public partial class _Default : System.Web.UI.Page
    {
        #region Declarations

        delegate string SlowThing();
        MySlowObject _slowObj = new MySlowObject();
        SlowThing _method1;
        SlowThing _method2;
        Stopwatch _stopwatch = new Stopwatch();
        StringBuilder _msg = new StringBuilder();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Async Stuff

            Page.RegisterAsyncTask(new PageAsyncTask(StartAsyncHandler1, EndAsyncHandler1, TimeoutHandler, null, true));
            Page.RegisterAsyncTask(new PageAsyncTask(StartAsyncHandler2, EndAsyncHandler2, TimeoutHandler, null, true));

            #endregion

            _stopwatch.Start();
            this.PreRenderComplete += new EventHandler(_Default_PreRenderComplete);

            #region Prodedural slowness...
            MySlowObject obj = new MySlowObject();
            //_msg.AppendFormat("<br />{0}", obj.SlowMethod1());
            //_msg.AppendFormat("<br />{0}", obj.SlowMethod2());
            #endregion

        }

        void _Default_PreRenderComplete(object sender, EventArgs e)
        {
            _msg.AppendFormat("<br />Total time for page to render = {0} milliseconds", _stopwatch.ElapsedMilliseconds);
            litMsg.Text = _msg.ToString();
        }

        #region Async Stuff

        IAsyncResult StartAsyncHandler1(object sender, EventArgs e,AsyncCallback cb, object state)
        {
            _method1 = new SlowThing(_slowObj.SlowMethod1);
            return _method1.BeginInvoke(cb, state);
        }
        IAsyncResult StartAsyncHandler2(object sender, EventArgs e, AsyncCallback cb, object state)
        {
            _method2 = new SlowThing(_slowObj.SlowMethod2);
            return _method2.BeginInvoke(cb, state);
        }

        void EndAsyncHandler1(IAsyncResult ar)
        {
            string result = _method1.EndInvoke(ar);
            _msg.Append("<br />" + result);
        }
        void EndAsyncHandler2(IAsyncResult ar)
        {
            string result = _method2.EndInvoke(ar);
            _msg.Append("<br />" + result);
        }

        void TimeoutHandler(IAsyncResult ar)
        {
        }
        #endregion
    }
}
