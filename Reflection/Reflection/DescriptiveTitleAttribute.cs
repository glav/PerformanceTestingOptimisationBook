using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class DescriptiveTitleAttribute : Attribute
    {
        public DescriptiveTitleAttribute() { }
        public DescriptiveTitleAttribute(string displayTitle)
        { 
            DisplayTitle = displayTitle;
        }

        public string DisplayTitle { get; set; }
    }
}
