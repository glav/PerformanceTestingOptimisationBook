using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsyncPages
{
    public class MySlowObject
    {
        public string SlowMethod1()
        {
            int timeToSleep = 2000;
            System.Threading.Thread.Sleep(timeToSleep);
            return string.Format("Method1 slept for {0} milliseconds", timeToSleep);
        }

        public string SlowMethod2()
        {
            int timeToSleep = 3500;
            System.Threading.Thread.Sleep(timeToSleep);
            return string.Format("Method2 slept for {0} milliseconds", timeToSleep);
        }
    }
}
