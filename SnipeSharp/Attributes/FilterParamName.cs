using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnipeSharp.Attributes
{
    /// <summary>
    /// Used to tag class properties with the name we should use in the URL query
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterParamName : Attribute
    {
        public FilterParamName(string paramName)
        {
            this.ParamName = paramName;
        }
        
        public string ParamName { get; }
    }
}


