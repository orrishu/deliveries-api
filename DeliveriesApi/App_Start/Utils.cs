using DeliveriesApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static Employee ParamValueEmployee(int val, DataTable dtemp)
        {
            try
            {
                if (val != 0)
                {
                     Employee e1 = (from emp in dtemp.AsEnumerable()
                                          where emp["EmployeeID"].ToString() == val.ToString()
                                    select new Employee()
                                          {
                                              EmployeeID = Convert.ToInt32(emp["EmployeeID"]),
                                              EmployeeName = emp["EmployeeName"].ToString()
                                          }).First();
                    return new Employee { EmployeeID = e1.EmployeeID, EmployeeName = e1.EmployeeName };
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static DeliveryStatus ParamValueStatus(int val, DataTable dtemp)
        {
            try
            {
                if (val != 0)
                {
                    DeliveryStatus s1 = (from sta in dtemp.AsEnumerable()
                                   where sta["StatusID"].ToString() == val.ToString()
                                   select new DeliveryStatus()
                                   {
                                       StatusID = Convert.ToInt32(sta["StatusID"]),
                                       StatusName = sta["StatusName"].ToString()
                                   }).First();
                    return new DeliveryStatus { StatusID = s1.StatusID, StatusName = s1.StatusName };
                }
                else
                    return null;
            }
            catch
            {
                return null;
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