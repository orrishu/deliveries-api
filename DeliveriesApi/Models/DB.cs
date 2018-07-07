using DataAccessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class DB
    {
        enum CourierType
        {
            Collect = 1,
            Deliver = 2,
            Third = 3
        }

        //entity framework usage - single item
        public TenderItem GetTenderItem(int iTenderID)
        {
            MyDB context = new MyDB();
            SqlParameter tenderID = new SqlParameter("@TenderID", iTenderID);

            object[] parameters = new object[] { tenderID };
            TenderItem oTender = context.Tender.SqlQuery("Tenders2017_GetTender @TenderID", parameters).Single();

            context.Dispose();
            context = null;
            return oTender;
        }

        ////entity framework usage - multiple items
        //internal List<Branch> GetBranches()
        //{
        //    MyDB context = new MyDB();
            
        //    List<Branch> lst = context.Branches.SqlQuery("Tenders2017_GetBranches").ToList();

        //    context.Dispose();
        //    context = null;
        //    return lst;
        //}

        //DAL usage
        internal DataTable GetDeliveries(string filters, string sort)
        {
            string sSelect = "select * from Rakaz_SQL ";
            string sWhere = "";
            string sSort = "";

            DBManager oDal = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["MyDB"].ToString());
            oDal.Open();
            //oDal.CreateParameters(1);
            //oDal.AddParameters(0, "@CompanyName", sCompanyName);
            //http://localhost:56110/api/deliveries/getdeliveries?page=1&pagesize=11&filters=[{"field":"cityName","value":"יבנה"}]

            if (filters != "")
            {
                List<FilterItem> lstFilter = JsonConvert.DeserializeObject<List<FilterItem>>(filters);
            
                foreach (FilterItem f in lstFilter)
                {
                    sWhere = sWhere + (sWhere=="" ? " " : " and ") +  f.field + " = '" + f.value + "'";
                }
            }

            if(sWhere != "")
                sSelect = sSelect + " where " + sWhere ;

            // Do Sort
            if (sort != "")
            {
                List<sortItem> lstSort = JsonConvert.DeserializeObject<List<sortItem>>(sort);
                foreach (sortItem s in lstSort)
                {
                    string sSortType = (s.isAscending ? "asc" : "desc");
                    
                    sSort = sSort + (sSort == "" ? " " : " , ") + s.field + " " + sSortType + " ";
                }
            }

            if (sSort != "")
                sSelect = sSelect + " Order By " + sSort;


            DataTable dt = oDal.ExecuteDataSet(CommandType.Text, sSelect).Tables[0];
            oDal.Close();
            oDal.Dispose();
            oDal = null;

            return dt;
        }

        internal DataTable GetDeliveryStatus()
        {
            DBManager oDal = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["MyDB"].ToString());

            //oDal.CreateParameters(1);
            //oDal.AddParameters(0, "@CompanyName", sCompanyName);

            oDal.Open();
            DataTable dt = oDal.ExecuteDataSet(CommandType.Text, "select * from Lkup_DeliveryStatus").Tables[0];
            oDal.Close();
            oDal.Dispose();
            oDal = null;

            return dt;
        }

        internal DataTable GetVehicleType()
        {
            DBManager oDal = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["MyDB"].ToString());

            //oDal.CreateParameters(1);
            //oDal.AddParameters(0, "@CompanyName", sCompanyName);

            oDal.Open();
            DataTable dt = oDal.ExecuteDataSet(CommandType.Text, "select * from Lkup_VehicleType").Tables[0];
            oDal.Close();
            oDal.Dispose();
            oDal = null;

            return dt;
        }

        internal DataTable GetEmployees()
        {
            DBManager oDal = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["MyDB"].ToString());

            //oDal.CreateParameters(1);
            //oDal.AddParameters(0, "@CompanyName", sCompanyName);

            oDal.Open();
            DataTable dt = oDal.ExecuteDataSet(CommandType.Text, "select EmployeeID, EmployeeName from Employee").Tables[0];
            oDal.Close();
            oDal.Dispose();
            oDal = null;

            return dt;
        }

        internal string SetDeliveryEmployee(int DeliveryNumber, int EmployeeID, int Type)
        {
            string res = "0";
            DBManager oDal = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["MyDB"].ToString());
            oDal.Open();
            oDal.CreateParameters(2);
            oDal.AddParameters(0, "@DeliveryNumber", DeliveryNumber);
            oDal.AddParameters(1, "@EmployeeID", EmployeeID);
           
            switch(Type)
            {
                case (int)CourierType.Collect:
                    res = oDal.ExecuteScalar(CommandType.StoredProcedure, "web_sp_SetDeliveryEmployeeID").ToString();
                    break;
                case (int)CourierType.Deliver:
                    res = oDal.ExecuteScalar(CommandType.StoredProcedure, "web_sp_SetDeliveryemployeeIDsec").ToString();
                    break;
                case (int)CourierType.Third:
                    res = oDal.ExecuteScalar(CommandType.StoredProcedure, "web_sp_SetDeliveryEmployeeID_Third").ToString();
                    break;

            }
            
            oDal.Close();
            oDal.Dispose();
            oDal = null;

            return res;
        }

        internal string SetDeliveryStatus(int DeliveryNumber, int StatusID)
        {
            string res = "0";
            DBManager oDal = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["MyDB"].ToString());
            oDal.Open();
            oDal.CreateParameters(2);
            oDal.AddParameters(0, "@DeliveryNumber", DeliveryNumber);
            oDal.AddParameters(1, "@DeliveryStatus", StatusID);

            res = oDal.ExecuteScalar(CommandType.StoredProcedure, "web_sp_SetDeliveryStatus").ToString();

            oDal.Close();
            oDal.Dispose();
            oDal = null;

            return res;
        }

        
    }
}