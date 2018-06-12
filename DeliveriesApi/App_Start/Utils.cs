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
            try
            { 
            return String.IsNullOrEmpty(val) ? 0 : Convert.ToInt32(val);
            }
            catch
            {
                return 0;
            }
        }
        public static string ParamValuestring(string val)
        {
            try
            {
                return String.IsNullOrEmpty(val) ? "" : val.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static DateTime ParamValueDate(string val)
        {
            try
            {
                return String.IsNullOrEmpty(val) ? DateTime.MinValue : Convert.ToDateTime(val);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
                                         


        public static string ParamYesNo(int val)
        {
            return val==1 ? "כן" : "לא";
        }
        
    }
}