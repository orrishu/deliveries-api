using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Util
{
    public class Utils
    {
        public static object ParamValue(string val)
        {
            return String.IsNullOrEmpty(val) ? DBNull.Value : (object)val;
        }

        public static int ParamValueInt(string val)
        {
            return String.IsNullOrEmpty(val) ? 0 : Convert.ToInt32(val);
        }

        public static string ParamYesNo(int val)
        {
            return val==1 ? "כן" : "לא";
        }
        
    }
}